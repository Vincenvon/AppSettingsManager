using AppSettingsManager.Requests;
using AppSettingsManager.Responses;

namespace AppSettingsManager.Services
{
    public interface ISettingsService
    {
        SettingResponse Read();

        SettingResponse Update(SettingRequest setting);
    }
}
