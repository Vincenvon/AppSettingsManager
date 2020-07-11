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
                .AddAppSettingsManager(new Settings.Settings());
        }

        public static IServiceCollection AddAppSettingsManager(this IServiceCollection services, Settings.Settings appSettingsManagerOptions)
        {
            return services
                .AddScoped<Settings.Settings>(s => appSettingsManagerOptions)
                .AddScoped<IRepository<Setting>>(s => new SettingsRepository(appSettingsManagerOptions.DatabaseSettings.FolderPath,
                appSettingsManagerOptions.DatabaseSettings.FileName))
                .AddScoped<ISettingsService, SettingsService>()
                .AddScoped<IHistoryService, HistoryService>();
        }
    }
}
