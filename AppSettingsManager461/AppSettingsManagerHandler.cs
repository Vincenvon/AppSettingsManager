using AppSettingsManager.Settings;

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppSettingsManager461
{
    public class AppSettingsManagerHandler: DelegatingHandler
    {
        private readonly AppSettingsManagerSetting _appSettingsManagerSetting;

        public AppSettingsManagerHandler(AppSettingsManagerSetting appSettingsManagerSetting)
        {
            this._appSettingsManagerSetting = appSettingsManagerSetting;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var requestUrl = request.RequestUri.LocalPath;

            if (requestUrl.Equals(this._appSettingsManagerSetting.AppSettingsManagerUrl, StringComparison.InvariantCultureIgnoreCase))
            {
                return Task.FromResult(CreateResponse(request));
            }
            else
            {
                return base.SendAsync(request, cancellationToken);
            }
        }


        private static HttpResponseMessage CreateResponse(HttpRequestMessage request)
        {
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "AsmContent/index.html");
            var indexFile = File.ReadAllText(filePath);
            var response = request.CreateResponse(HttpStatusCode.OK);

            response.Content = new StringContent(indexFile, Encoding.UTF8, "text/html");

            return response;
        }
    }
}
