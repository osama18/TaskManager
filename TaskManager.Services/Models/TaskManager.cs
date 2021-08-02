using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Services.Factories.Process;
using TaskManager.Services.Models.Process;
using TaskManager.Services.Services;

namespace TaskManager.Services.Models
{
    internal class TaskManager: ITaskManager
    {
        private readonly IMemory memory;
        private readonly ISortingAlgorithm sortingAlgorithm;
        private readonly IProcessFactory processFactory;
        
        public TaskManager(IMemory memory,
            ISortingAlgorithm sortingAlgorithm,
            IProcessFactory processFactory)
        {
            this.memory = memory;
            this.sortingAlgorithm = sortingAlgorithm;
            this.processFactory = processFactory;
        }

        public bool Add(IProcess process)
        {
            return memory.Add(process);
        }

        public IProcess[] List(SortOption sortOption)
        {
            var processs = memory
                .List()
                .Select(s => processFactory.Construct(s, sortOption)).ToArray();

            var result = sortingAlgorithm.Sort(processs);

            return result;
        }

        public void KillIProcess(IProcess process)
        {
            memory.KillIProcess(process);
        }

        public void KillIProcessGroup(string groupName)
        {
            memory.KillIProcessGroup(groupName);
        }

        public void KillAll()
        {
            memory.KillAll();
        }
    }
}
