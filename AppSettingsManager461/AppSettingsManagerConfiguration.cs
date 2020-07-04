using AppSettingsManager.Settings;

using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace AppSettingsManager461
{
    public static class AppSettingsManagerConfiguration
    {
        public static HttpConfiguration ConfigureAppSettingsManager(this HttpConfiguration httpConfiguration)
        {
            return httpConfiguration.ConfigureAppSettingsManager(new AppSettingsManagerSetting {
                DbFilePath = $"{AppDomain.CurrentDomain.BaseDirectory}\\AsmDb"
            });
        }

        public static HttpConfiguration ConfigureAppSettingsManager(
            this HttpConfiguration httpConfiguration,
            AppSettingsManagerSetting appSettingsManagerOptions)
        {
            httpConfiguration.Routes.MapHttpRoute(
                name: "AppSettingsRoute",
                routeTemplate: "appsettings",
                defaults: null,
                constraints: null,
                handler: HttpClientFactory.CreatePipeline(
                          new HttpControllerDispatcher(httpConfiguration),
                          new DelegatingHandler[] { new AppSettingsManagerHandler(appSettingsManagerOptions) })
                );

            SettingsProvider.Setting = appSettingsManagerOptions;

            return httpConfiguration;
        }
    }
}
