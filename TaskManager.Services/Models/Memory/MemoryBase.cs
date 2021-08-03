
using System.Collections.Generic;
using System.Linq;
using TaskManager.Services.Models.Process;

namespace TaskManager.Services.Models
{
    public abstract class MemoryBase
    {
        protected ICollection<IProcess> processList;
        private readonly long capacity;

        public MemoryBase(long capacity)
        {
            this.capacity = capacity;
        }

        public ICollection<IProcess> List()
        {
            return processList;
        }
        public void KillIProcess(IProcess process)
        {
            process.Kill();
            processList.Remove(process);
        }

        public void KillIProcessGroup(string groupName)
        {
            processList = processList.Where(s => s.GroupName != groupName).ToList();
        }

        public bool Add(IProcess process)
        {
            if (processList.Count <= capacity)
            {
                processList.Add(process);
                return true;
            }

            return OnCompleteAdd(process);
        }

        public IProcess Get(long processId)
        {
            throw new System.NotImplementedException();
        }
        protected abstract bool OnCompleteAdd(IProcess process);
    }
}
