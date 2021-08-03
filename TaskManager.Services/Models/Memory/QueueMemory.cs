using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Services.Models.Process;
using TaskManagers.DAL.Repostiories;

namespace TaskManager.Services.Models.Memory
{
    internal class QueueMemory : MemoryBase, IMemory
    {
        private readonly IProcessRepository processRepository;
        public QueueMemory(IProcessRepository processRepository,
            IMapper mapper,
            long capacity) : base(processRepository, mapper, capacity)
        {
            this.processRepository = processRepository;
        }

        protected override async Task<long?> OnCompleteAdd(IProcess process)
        {
            await processRepository.RemoveOldest();
            return await AddAsync(process);
        }
    }
}
