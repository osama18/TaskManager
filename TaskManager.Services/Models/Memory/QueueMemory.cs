using System.Collections.Generic;
using TaskManager.Services.Models.Process;

namespace TaskManager.Services.Models.Memory
{
    internal class QueueMemory : MemoryBase, IMemory
    {
        public QueueMemory(long capacity) : base(capacity)
        {
            processList = new List<IProcess>();
        }

        public void KillAll()
        {
            processList = new List<IProcess>();
        }

        protected override bool OnCompleteAdd(IProcess process)
        {
            var enumerator = processList.GetEnumerator();
            processList.Remove(enumerator.Current);
            processList.Add(process);
            return true;
        }
    }
}
