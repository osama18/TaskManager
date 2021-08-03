using Microsoft.Extensions.DependencyInjection;
using TaskManagers.Common.Logging;
using TaskManagers.Common.Settings;

namespace TaskManagers.Common
{
    public static class Registration
    {
        public static IServiceCollection RegisterCommon(this IServiceCollection collection)
        {
            collection.AddSingleton<ISettingProvider, ConfigSettingsProvider>(); 
            return collection.AddSingleton<ILogger, Logger>();
        }
    }
}
