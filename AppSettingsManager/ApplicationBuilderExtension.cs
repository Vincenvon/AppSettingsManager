using AppSettingsManager.Settings;

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
            return applicationBuilder.UseAppSettingsManager(new AppSettingsManagerSetting());
        }

        public static IApplicationBuilder UseAppSettingsManager(this IApplicationBuilder applicationBuilder, AppSettingsManagerSetting appSettingsManagerOptions)
        {
            applicationBuilder
                .UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(
                         Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "AsmContent")
                        ),
                    RequestPath = "/asmcontent"
                })
                .UseMiddleware<AppSettingsManagerMiddleware>(appSettingsManagerOptions);
            return applicationBuilder;
        }
    }
}
