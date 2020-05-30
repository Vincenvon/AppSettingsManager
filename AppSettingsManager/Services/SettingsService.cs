using AppSettingsManager.Models;

using System;
using System.Threading.Tasks;

namespace AppSettingsManager.Services
{
    public class SettingsService : ISettingsService
    {
        public Task<SettingModel> ReadAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SettingModel> UpdateAsync(SettingModel setting)
        {
            throw new NotImplementedException();
        }
    }
}
