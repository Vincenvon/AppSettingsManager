using AppSettingsManager.Models;

using System.IO;
using System.Reflection;

namespace AppSettingsManager.Services
{
    public class SettingsService : ISettingsService
    {
        public SettingModel Read()
        {
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "appsettings.json");
            var text = System.IO.File.ReadAllText(filePath);
            return new SettingModel
            {
                Json = text
            };
        }

        public SettingModel Update(SettingModel setting)
        {
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "appsettings.json");
            System.IO.File.WriteAllText(filePath, setting.Json);
            return setting;
        }
    }
}
