using AppSettingsManager.DataAccess;
using AppSettingsManager.Entities;
using AppSettingsManager.Settings;

using System.Web.Http;

namespace AppSettingsManager461
{
    public static class AppSettingsManagerConfiguration
    {
        public static HttpConfiguration ConfigureAppSettingsManager(this HttpConfiguration httpConfiguration, AppSettingsManagerSetting appSettingsManagerOptions)
        {
            var services = httpConfiguration.Services;

            services.Add(typeof(AppSettingsManagerSetting), appSettingsManagerOptions);
            services.Add(typeof(IRepository<Setting>), new SettingsRepository(appSettingsManagerOptions.DbFilePath, appSettingsManagerOptions.DbFileName));

            return services
                .AddScoped<AppSettingsManagerSetting>(s => appSettingsManagerOptions)
                .AddScoped<>(s => )
                .AddScoped<ISettingsService, SettingsService>()
                .AddScoped<IHistoryService, HistoryService>();
        }
    }
}
