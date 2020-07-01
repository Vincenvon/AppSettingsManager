using AppSettingsManager.DataAccess;
using AppSettingsManager.Entities;
using AppSettingsManager.Services;
using AppSettingsManager.Settings;

using Microsoft.Extensions.DependencyInjection;

using System.IO;
using System.Reflection;

namespace AppSettingsManager
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddAppSettingsManager(this IServiceCollection services)
        {
            return services
                .AddAppSettingsManager(new AppSettingsManagerSetting());
        }

        public static IServiceCollection AddAppSettingsManager(this IServiceCollection services, AppSettingsManagerSetting appSettingsManagerOptions)
        {
            if (!Directory.Exists(appSettingsManagerOptions.DbFilePath))
                Directory.CreateDirectory(appSettingsManagerOptions.DbFilePath);

            return services
                .AddScoped<AppSettingsManagerSetting>(s => appSettingsManagerOptions)
                .AddScoped<IRepository<Setting>>(s => new SettingsRepository(appSettingsManagerOptions.DbFilePath, appSettingsManagerOptions.DbFileName))
                .AddScoped<ISettingsService, SettingsService>()
                .AddScoped<IHistoryService, HistoryService>();
        }
    }
}
