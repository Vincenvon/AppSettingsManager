using AppSettingsManager.Services;

using Microsoft.Extensions.DependencyInjection;

namespace AppSettingsManager
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddAppSettingsManager(this IServiceCollection services)
        {
            return services.AddScoped<ISettingsService, SettingsService>();
        }
    }
}
