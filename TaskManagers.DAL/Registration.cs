using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using System;
using TaskManagers.DAL.DbContext;
using TaskManagers.DAL.Repostiories;

namespace TaskManagers.DAL
{
    public static class Registration
    {
        public static IServiceCollection RegisterDal(this IServiceCollection collection)
        {
            collection.AddTransient<ITaskManagersDbContext, TaskManagersDbContext>();
            collection.AddTransient<IProcessRepository, ProcessRepository>();

            var migrateConnectionString = Environment.GetEnvironmentVariable("TaskManagersConnectionString");
            collection.AddDbContext<TaskManagersDbContext>(options =>
                    options.UseSqlServer(migrateConnectionString));

            return collection;
        }
    }
}
