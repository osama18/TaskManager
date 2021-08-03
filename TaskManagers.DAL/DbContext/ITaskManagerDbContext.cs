using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagers.DAL.Entities;

namespace TaskManagers.DAL.DbContext
{
    interface ITaskManagersDbContext
    {
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Gets or sets the Process.
        /// </summary>
        public DbSet<ProcessEntity> Processes { get; set; }

        DbSet<T> Set<T>() where T : class;

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();

        Task<long?> AddAsync(Entity entity);

        Task AddRangeAsync(IEnumerable<Entity> entities);

        void Update(Entity entity);
    }
}