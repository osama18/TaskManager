using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Services.Models.Process;
using TaskManagers.DAL.Repostiories;

namespace TaskManager.Services.Models.Memory
{
    internal class HeapMemory : MemoryBase, IMemory
    {
        private readonly IProcessRepository processRepository;
        public HeapMemory(IProcessRepository processRepository,
            IMapper mapper,
            long capacity): base(processRepository, mapper,capacity)
        {
            this.processRepository = processRepository;
        }

        protected override Task<long?> OnCompleteAdd(IProcess process)
        {
            return null;
        }

    }
}
