using AppSettingsManager.Settings;
using AppSettingsManager.Setup;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;

using System.IO;
using System.Reflection;

namespace AppSettingsManager
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseAppSettingsManager(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseAppSettingsManager(new Settings.Settings());
        }

        public static IApplicationBuilder UseAppSettingsManager(this IApplicationBuilder applicationBuilder, Settings.Settings appSettingsManagerOptions)
        {
            Setuper.SetupAsync(appSettingsManagerOptions).Wait();

            applicationBuilder
                .UseMiddleware<AppSettingsManagerMiddleware>(appSettingsManagerOptions);
            return applicationBuilder;
        }
    }
}
