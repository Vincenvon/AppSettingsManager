using AppSettingsManager.Authentication;
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
            services.AddAuthentication("Bearer")
                .AddScheme<AppSettingsManagerAuthenticationSchemeOptions, AppSettingsManagerAuthenticationHandler>("Bearer", null);

            return services
                .AddScoped<Settings.Settings>(s => appSettingsManagerOptions)
                .AddScoped<IRepository<User>>(s => new Repository<User>(appSettingsManagerOptions.DatabaseSettings.FolderPath,
                appSettingsManagerOptions.DatabaseSettings.FileName))
                .AddScoped<IRepository<Setting>>(s => new Repository<Setting>(appSettingsManagerOptions.DatabaseSettings.FolderPath,
                appSettingsManagerOptions.DatabaseSettings.FileName))
                .AddScoped<ISettingsService, SettingsService>()
                .AddScoped<IHistoryService, HistoryService>()
                .AddScoped<IJwtTokenService, JwtTokenService>(s => new JwtTokenService(appSettingsManagerOptions.JwtTokenSettings))
                .AddScoped<IUserManager, UserManager>();
        }
    }
}