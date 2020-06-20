using AppSettingsManager.DataAccess;
using AppSettingsManager.Entity;
using AppSettingsManager.Services;

using LiteDB;

using Microsoft.Extensions.DependencyInjection;

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
            return services
                .AddScoped<ILiteDatabase>(s => new LiteDatabase(appSettingsManagerOptions.DbPath))
                .AddScoped<IRepository<Setting>, SettingsRepository>()
                .AddScoped<ISettingsService, SettingsService>()
                .AddScoped<IHistoryService, HistoryService>();
        }
    }
}
