using Microsoft.Extensions.DependencyInjection;
using TaskManager.Services.Factories;
using TaskManager.Services.Factories.Memory;
using TaskManager.Services.Factories.Process;
using TaskManager.Services.Factories.SortingAlgorithm;
using TaskManager.Services.Services;
using TaskManagers.DAL;

namespace TaskManager.Services
{
    public static class Registration
    {
        public static IServiceCollection RegisterBusiness(this IServiceCollection collection)
        {
            collection.RegisterDal();
            collection.AddAutoMapper(typeof(Mappers.AutoMapping));
            collection.AddTransient<IMemoryFactory, MemoryFactory>();
            collection.AddTransient<IProcessFactory, ProcessFactory>();
            collection.AddTransient<ISortingAlgorithmFactory, SortingAlgorithmFactory>();
            return collection.AddTransient<ITaskManagerServices, TaskManagerServices>();
            
        }
    }
}
