using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using System;


namespace TaskManagers.DAL.DbContext
{
    
    public class TaskManagersDbContextFactory : IDesignTimeDbContextFactory<TaskManagersDbContext>
    {
        public TaskManagersDbContext CreateDbContext(string[] args)
        {
            var migrateConnectionString = Environment.GetEnvironmentVariable("TaskManagersConnectionString");
            if (string.IsNullOrWhiteSpace(migrateConnectionString))
            {
                throw new Exception("TaskManagers environment variable does not contain any connectionstring.");
            }

            var optionsBuilder = new DbContextOptionsBuilder<TaskManagersDbContext>();
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer(migrateConnectionString, x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName));
            return new TaskManagersDbContext(optionsBuilder.Options);
        }

    }
}
