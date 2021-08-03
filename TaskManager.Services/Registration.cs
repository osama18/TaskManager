using Microsoft.Extensions.DependencyInjection;
using TaskManager.Services.Services;

namespace TaskManager.Services
{
    public static class Registration
    {
        public static IServiceCollection RegisterBusiness(this IServiceCollection collection)
        {
            //  collection.RegisterDal();
            //collection.AddAutoMapper(typeof(Mappers.AutoMapping));
            return collection.AddTransient<ITaskManagerServices, TaskManagerServices>();
            
        }
    }
}
