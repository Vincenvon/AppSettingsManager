using System.Threading.Tasks;

namespace AppSettingsManager.Setup
{
    public static class Setuper
    {
        public static async Task SetupAsync(Settings.Settings settings)
        {
            await ContentSetuper.SetupAsync(settings.ContentSettings);
            await DatabaseSetuper.SetupAsync(settings.DatabaseSettings);
        }
    }
}
