using Microsoft.AspNetCore.Http;

using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace AppSettingsManager
{
    public class AppSettingsManagerMiddleware
    {
        private readonly AppSettingsManagerOptions _appSettingsManagerOptions;
        private readonly RequestDelegate next;

        public AppSettingsManagerMiddleware(RequestDelegate next, AppSettingsManagerOptions appSettingsManagerOptions)
        {
            this.next = next;
            this._appSettingsManagerOptions = appSettingsManagerOptions;
        }

        /// <summary>
        /// Method wraps all next middlewares to try/catch block and invokes them
        /// </summary>
        /// <param name="httpContext">Current http context</param>
        /// <returns></returns>
        public async Task Invoke(HttpContext httpContext)
        {
            var requestUrl = httpContext.Request.Path.Value;

            if (requestUrl.Contains(this._appSettingsManagerOptions.AppSettingsManagerUrl))
            {
                await WriteResponseAsync(httpContext);
            }
            else
            {
                await this.next(httpContext);
            }
        }

        private static Task WriteResponseAsync(HttpContext context)
        {
            context.Response.StatusCode = 200;
            context.Response.ContentType = "text/html";

            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "AppSettingsManagerContent/index.html");
            var indexFile = File.ReadAllText(filePath);
            return context.Response.WriteAsync(indexFile);
        }
    }
}
