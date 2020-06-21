using AppSettingsManager.DataAccess;
using AppSettingsManager.Entity;
using AppSettingsManager.Services;

using LiteDB;

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
                .AddAppSettingsManager(new AppSettingsManagerOptions());
        }

        public static IServiceCollection AddAppSettingsManager(this IServiceCollection services, AppSettingsManagerOptions appSettingsManagerOptions)
        {
            if (!Directory.Exists(appSettingsManagerOptions.DbFilePath))
                Directory.CreateDirectory(appSettingsManagerOptions.DbFilePath);

            var dbPath = Path.Combine(appSettingsManagerOptions.DbFilePath, appSettingsManagerOptions.DbFileName);

            return services
                .AddScoped<AppSettingsManagerOptions>(s => appSettingsManagerOptions)
                .AddScoped<ILiteDatabase>(s => new LiteDatabase(dbPath))
                .AddScoped<IRepository<Setting>, SettingsRepository>()
                .AddScoped<ISettingsService, SettingsService>()
                .AddScoped<IHistoryService, HistoryService>();
        }
    }
}
