using AppSettingsManager.Settings;

using Microsoft.AspNetCore.Http;

using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace AppSettingsManager
{
    public class AppSettingsManagerMiddleware
    {
        private readonly Settings.Settings _appSettingsManagerOptions;
        private readonly RequestDelegate next;

        public AppSettingsManagerMiddleware(RequestDelegate next, Settings.Settings appSettingsManagerOptions)
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

            if (requestUrl.Equals(this._appSettingsManagerOptions.HostSettings.Url, StringComparison.InvariantCultureIgnoreCase))
            {
                await WriteResponseAsync(httpContext);
            }
            else
            {
                await this.next(httpContext);
            }
        }

        private Task WriteResponseAsync(HttpContext context)
        {
            context.Response.StatusCode = 200;
            context.Response.ContentType = "text/html";

            var filePath = Path.Combine(_appSettingsManagerOptions.ContentSettings.HtmlFolderPath,"index.html");
            var indexFile = File.ReadAllText(filePath);
            return context.Response.WriteAsync(indexFile);
        }
    }
}
