using AppSettingsManager.Settings;

using System.IO;
using System.Web;
using System.Web.Http;

namespace AppSettingsManager461.TestClient
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API

            config.ConfigureAppSettingsManager(new Settings
            {
                ContentSettings = new ContentSettings
                {
                    HtmlFolderPath = Path.Combine(HttpRuntime.AppDomainAppPath, "wwwroot"),
                    HtmlRequestPath = "",
                    ImagesFolderPath = Path.Combine(HttpRuntime.AppDomainAppPath, "wwwroot\\images"),
                    ImagesRequestPath = "wwwroot/images",
                    JsFolderPath = Path.Combine(HttpRuntime.AppDomainAppPath, "wwwroot\\js"),
                    JsRequestPath = "wwwroot/js",
                },
                FileSettings = new FileSettings
                {
                    FilePath = HttpRuntime.AppDomainAppPath,
                }
            });

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
