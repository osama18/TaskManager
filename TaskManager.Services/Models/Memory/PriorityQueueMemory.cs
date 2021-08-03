
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Services.Models.Process;
using TaskManager.Services.Models.Process.DecoratedProcesses;
using TaskManagers.DAL.Repostiories;

namespace TaskManager.Services.Models.Memory
{
    internal class PriorityQueueMemory : MemoryBase, IMemory
    {
        private readonly IProcessRepository processRepository;
        public PriorityQueueMemory(IProcessRepository processRepository,
            IMapper mapper,
            long capacity) : base(processRepository, mapper, capacity)
        {
            this.processRepository = processRepository;
        }

        protected override async Task<long?> OnCompleteAdd(IProcess process)
        {
            await processRepository.RemoveOldestLowestPriority();
            return await AddAsync(process);
        }

    }
}
