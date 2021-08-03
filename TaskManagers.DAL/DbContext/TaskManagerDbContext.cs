using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagers.DAL.Configuration;
using TaskManagers.DAL.Entities;

namespace TaskManagers.DAL.DbContext
{
    public class TaskManagersDbContext : Microsoft.EntityFrameworkCore.DbContext, ITaskManagersDbContext
    {
        public TaskManagersDbContext()
        {
        }

        public TaskManagersDbContext(DbContextOptions<TaskManagersDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new ProcessConfiguration());


            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            
            modelBuilder.Entity<ProcessEntity>().ToTable(nameof(ProcessEntity));
        }

        /// <summary>
        /// Gets or sets the Process.
        /// </summary>
        public DbSet<ProcessEntity> Processes { get; set; }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public void Update(Entity entity) => base.Update(entity);

        public async Task<long?> AddAsync(Entity entity) => (await base.AddAsync(entity))?.Entity?.Id;

        public async Task AddRangeAsync(IEnumerable<Entity> entities) => await base.AddRangeAsync(entities);
    }
}
