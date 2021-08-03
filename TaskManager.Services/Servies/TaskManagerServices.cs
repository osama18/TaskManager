using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Services.Factories;
using TaskManager.Services.Factories.Memory;
using TaskManager.Services.Factories.Process;
using TaskManager.Services.Factories.SortingAlgorithm;
using TaskManager.Services.Models;
using TaskManager.Services.Models.Process;

namespace TaskManager.Services.Services
{
    internal class TaskManagerServices: ITaskManagerServices
    {
        private readonly IMemory memory;
        private readonly ISortingAlgorithm sortingAlgorithm;
        private readonly IProcessFactory processFactory;
        
        public TaskManagerServices(IMemoryFactory memoryFactory,
            ISortingAlgorithmFactory sortingAlgorithmFactory,
            IProcessFactory processFactory)
        {
            this.memory= memoryFactory.Construct();
            this.sortingAlgorithm = sortingAlgorithmFactory.Construct();
            this.processFactory = processFactory;
        }

        public async Task<long?> AddAsync(Priority priority, string groupName)
        {
            var process = processFactory.Construct(priority, groupName);
            return await memory.AddAsync(process);
        }

        public async Task<ICollection<IProcess>> ListAsync(SortOption sortOption)
        {
            var processs = (await memory.ListAsync())
                .Select(s => processFactory.Construct(s, sortOption))
                .ToArray();

            var result = sortingAlgorithm.Sort(processs);

            return result;
        }

        public async Task KillIProcessAsync(long processId)
        {
            await memory.KillIProcessAsync(processId);
        }

        public async Task KillIProcessGroupAsync(string groupName)
        {
            await memory.KillIProcessGroupAsync(groupName);
        }

        public async Task KillAllAsync()
        {
            await memory.KillAllAsync();
        }
    }
}
