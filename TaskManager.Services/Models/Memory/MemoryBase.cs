
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models.Process;
using TaskManager.Services.Models.Process;
using TaskManagers.DAL.Entities;
using TaskManagers.DAL.Repostiories;

namespace TaskManager.Services.Models
{
    public abstract class MemoryBase
    {
        private readonly IProcessRepository processRepository;
        private readonly IMapper mapper;
        private readonly long capacity;
        
        public MemoryBase(IProcessRepository processRepository,
            IMapper mapper,
            long capacity)
        {
            this.processRepository = processRepository;
            this.mapper = mapper;
            this.capacity = capacity;
        }

        public async Task<IEnumerable<ProcessDto>> ListAsync(int take = 1000, int skip =0)
        {
            var list =  await processRepository.RetrievePage(take,skip);
            var result = list.Select(mapper.Map<ProcessDto>);
            return result;
        }
        public async Task KillIProcessAsync(long processId)
        {
            await processRepository.Remove(processId);
        }

        public async Task KillIProcessGroupAsync(string groupName)
        {
            await processRepository.Remove(groupName);
        }

        public async Task<long?> AddAsync(IProcess process)
        {
            var currentCount = await processRepository.Count();
            if (currentCount < capacity)
            {
                var processEntity = mapper.Map<ProcessEntity>(process);
                var id = await processRepository.InsertAsync(processEntity);
                return id;
            }

            return await OnCompleteAdd(process);
        }

        public async Task<ProcessDto> RetrieveAsync(long processId)
        {
            var processEntity = await processRepository.RetrieveById(processId);
            var result = mapper.Map<ProcessDto>(processEntity);
            return result;
        }
        public async Task KillAllAsync()
        {
            await processRepository.RemoveAll();
        }

        protected abstract Task<long?> OnCompleteAdd(IProcess process);
    }
}
