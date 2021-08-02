
using System.Collections.Generic;
using TaskManager.Services.Models.Process;
using TaskManager.Services.Models.Process.DecoratedProcesses;

namespace TaskManager.Services.Models.Memory
{
    internal class PriorityQueueMemory : MemoryBase, IMemory
    {
        public PriorityQueueMemory(long capacity) : base(capacity)
        {
            processList = new List<IProcess>();
        }

        protected override bool OnCompleteAdd(IProcess process)
        {
            IProcess min = GetMin();
            processList.Remove(min);
            processList.Add(process);
            return true;
        }
        public void KillAll()
        {
            processList = new List<IProcess>();
        }

        private IProcess GetMin()
        {
            var enumerator = processList.GetEnumerator();
            IProcess min = new PriorityDateComparableProcess(enumerator.Current);
            while (enumerator.MoveNext())
            {
                var current = new PriorityDateComparableProcess(enumerator.Current);
                if (current.CompareTo(min) == -1)
                    min = current;
            }
            return min;
        }
    }
}
