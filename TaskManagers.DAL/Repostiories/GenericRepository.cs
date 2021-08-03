using TaskManagers.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagers.DAL.DbContext;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TaskManagers.DAL.Repostiories
{
    internal abstract class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        private readonly ITaskManagersDbContext taskManagersDbContext;

        protected GenericRepository(ITaskManagersDbContext taskManagersDbContext)
        {
            this.taskManagersDbContext = taskManagersDbContext;
        }

        public async Task<long?> InsertAsync(T entity)
        {
            var result = await taskManagersDbContext.AddAsync(entity);

            return result?.Id;
        }

        public async Task InsertRangeAsync(IEnumerable<T> entities)
        {
            await taskManagersDbContext.AddRangeAsync(entities);
        }

        public void Update(Entity entity) => taskManagersDbContext.Update(entity);
        
        public async Task SaveAsync() => await taskManagersDbContext.SaveChangesAsync();

        public async Task<ICollection<T>> RetrievePage(int take , int skip = 0)
        {
            return await taskManagersDbContext
                .Set<T>()
                .Take(take)
                .Skip(skip)
                .ToListAsync();
        }

        public async Task<T> RetrieveById(long id)
        {
            return await taskManagersDbContext.Set<T>().FindAsync(id);
        }

        public async Task Remove(long id)
        {
            var process = await RetrieveById(id);
            taskManagersDbContext.Set<T>().Remove(process);
            await taskManagersDbContext.SaveChangesAsync();
        }

        public async Task RemoveRange(ICollection<T> processes)
        {
            taskManagersDbContext.Set<T>().RemoveRange(processes);
            await taskManagersDbContext.SaveChangesAsync();
        }

        public async Task RemoveAll()
        {
            taskManagersDbContext.Set<T>().RemoveRange(taskManagersDbContext.Set<T>());//ExecuteSqlCommand("TRUNCATE TABLE [TableName]");
            await taskManagersDbContext.SaveChangesAsync();
        }

        public async Task<long> Count()
        {
            return await taskManagersDbContext.Set<T>().CountAsync();
        }
    }
}