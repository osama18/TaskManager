﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Services.Factories.Process;
using TaskManager.Services.Models;
using TaskManager.Services.Models.Process;

namespace TaskManager.Services.Services
{
    internal class TaskManagerServices: ITaskManagerServices
    {
        private readonly IMemory memory;
        private readonly ISortingAlgorithm sortingAlgorithm;
        private readonly IProcessFactory processFactory;
        
        public TaskManagerServices(IMemory memory,
            ISortingAlgorithm sortingAlgorithm,
            IProcessFactory processFactory)
        {
            this.memory = memory;
            this.sortingAlgorithm = sortingAlgorithm;
            this.processFactory = processFactory;
        }

        public async Task<bool> AddAsync(Priority priority, string groupName)
        {
            var process = processFactory.Construct(priority, groupName);
            return memory.Add(process);
        }

        public async Task<ICollection<IProcess>> ListAsync(SortOption sortOption)
        {
            var processs = memory
                .List()
                .Select(s => processFactory.Construct(s, sortOption)).ToArray();

            var result = sortingAlgorithm.Sort(processs);

            return result;
        }

        public async Task KillIProcessAsync(long processId)
        {
            IProcess process = memory.Get(processId);
            memory.KillIProcess(process);
        }

        public async Task KillIProcessGroupAsync(string groupName)
        {
            memory.KillIProcessGroup(groupName);
        }

        public async Task KillAllAsync()
        {
            memory.KillAll();
        }
    }
}