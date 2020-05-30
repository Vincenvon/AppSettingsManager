using AppSettingsManager.Models;

using System.Threading.Tasks;

namespace AppSettingsManager.Services
{
    public interface ISettingsService
    {
        Task<SettingModel> ReadAsync();

        Task<SettingModel> UpdateAsync(SettingModel setting);
    }
}
