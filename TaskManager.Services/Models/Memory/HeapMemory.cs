using System.Collections.Generic;
using TaskManager.Services.Models.Process;

namespace TaskManager.Services.Models.Memory
{
    internal class HeapMemory : MemoryBase, IMemory
    {
        public HeapMemory(long capacity): base(capacity)
        {
            processList = new List<IProcess>();
        }
        public void KillAll()
        {
            processList = new List<IProcess>();
        }

        protected override bool OnCompleteAdd(IProcess process)
        {
            return false;
        }

    }
}
