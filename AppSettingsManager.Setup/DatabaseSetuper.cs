using AppSettingsManager.Settings;

using System.IO;
using System.Threading.Tasks;

namespace AppSettingsManager.Setup
{
    internal static class DatabaseSetuper
    {
        internal static Task SetupAsync(DatabaseSettings settings)
        {
            if (!Directory.Exists(settings.FolderPath))
                Directory.CreateDirectory(settings.FolderPath);

            return Task.FromResult(0);
        }
    }
}
