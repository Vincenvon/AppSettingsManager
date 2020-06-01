using AppSettingsManager.Models;

namespace AppSettingsManager.Services
{
    public interface ISettingsService
    {
        SettingModel Read();

        SettingModel Update(SettingModel setting);
    }
}
