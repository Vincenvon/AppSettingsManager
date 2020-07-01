using AppSettingsManager.DataAccess;
using AppSettingsManager.Entities;
using AppSettingsManager.Requests;
using AppSettingsManager.Responses;
using AppSettingsManager.Settings;

using System;
using System.IO;

namespace AppSettingsManager.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly AppSettingsManagerSetting _appSettingsManagerOptions;
      
        private readonly IRepository<Setting> _repository;

        public SettingsService(IRepository<Setting> repository, AppSettingsManagerSetting appSettingsManagerOptions)
        {
            _repository = repository;
            _appSettingsManagerOptions = appSettingsManagerOptions;
        }

        public SettingResponse Read()
        {
            var filePath = Path.Combine(_appSettingsManagerOptions.AppSettingsFilePath, _appSettingsManagerOptions.AppSettingsFileName);
            var text = System.IO.File.ReadAllText(filePath);
            return new SettingResponse
            {
                Json = text
            };
        }

        public SettingResponse Update(SettingRequest setting)
        {
            var filePath = Path.Combine(_appSettingsManagerOptions.AppSettingsFilePath, _appSettingsManagerOptions.AppSettingsFileName);
            System.IO.File.WriteAllText(filePath, setting.Json);

            _repository.Create(new Setting
            {
                Json = setting.Json,
                UpdatedDateTime = DateTime.UtcNow
            });

            return new SettingResponse {
                Json = setting.Json
            };
        }
    }
}
