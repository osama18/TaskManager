using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagers.DAL.DbContext;
using TaskManagers.DAL.Entities;

namespace TaskManagers.DAL.Repostiories
{
    internal class ProcessRepository : GenericRepository<ProcessEntity>, IProcessRepository
    {
        private readonly ITaskManagersDbContext taskManagersDbContext;
        public ProcessRepository(ITaskManagersDbContext taskManagersDbContext) : base(taskManagersDbContext)
        {
            this.taskManagersDbContext = taskManagersDbContext;
        }

        public async Task<ICollection<ProcessEntity>> RetrieveByGroup(string groupName)
        {
            return await taskManagersDbContext
                .Processes
                .Where(s => s.GroupName == groupName)
                .ToListAsync();
        }

        public async Task RemoveOldestLowestPriority()
        {
            var result = await taskManagersDbContext
                .Processes
                .OrderBy(s => s.Priority)
                .ThenBy(s => s.CreatedAt)
                .FirstOrDefaultAsync();

            if (result != null)
            {
                await Remove(result.Id);
                await taskManagersDbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveOldest()
        {
            var minDate = await taskManagersDbContext
              .Processes
              .Select(s => s.CreatedAt)
              .MinAsync();

            var result = await taskManagersDbContext
                .Processes.
                FirstOrDefaultAsync(s => s.CreatedAt == minDate);
            
            if (result != null)
            {
                await Remove(result.Id);
                await taskManagersDbContext.SaveChangesAsync();
            }
        }

        public async Task Remove(string groupName)
        {
            var processes = await RetrieveByGroup(groupName);
            await RemoveRange(processes);
            await taskManagersDbContext.SaveChangesAsync();
        }
    }
}
