using AppSettingsManager.Settings;
using AppSettingsManager.Setup;

using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace AppSettingsManager461
{
    public static class AppSettingsManagerConfiguration
    {
        public static HttpConfiguration ConfigureAppSettingsManager(this HttpConfiguration httpConfiguration)
        {
            return httpConfiguration.ConfigureAppSettingsManager(new Settings());
        }

        public static HttpConfiguration ConfigureAppSettingsManager(
            this HttpConfiguration httpConfiguration,
            Settings appSettingsManagerOptions)
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

            Setuper.SetupAsync(appSettingsManagerOptions).Wait();
            SettingsProvider.Setting = appSettingsManagerOptions;

            return httpConfiguration;
        }
    }
}
