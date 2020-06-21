using AppSettingsManager.DataAccess;
using AppSettingsManager.Entity;
using AppSettingsManager.Models;

using System;
using System.IO;
using System.Reflection;

namespace AppSettingsManager.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly AppSettingsManagerOptions _appSettingsManagerOptions;
        
        private readonly IRepository<Setting> _repository;

        public SettingsService(IRepository<Setting> repository, AppSettingsManagerOptions appSettingsManagerOptions)
        {
            _repository = repository;
            _appSettingsManagerOptions = appSettingsManagerOptions;
        }

        public SettingModel Read()
        {
            var filePath = Path.Combine(_appSettingsManagerOptions.AppSettingsFilePath, _appSettingsManagerOptions.AppSettingsFileName);
            var text = System.IO.File.ReadAllText(filePath);
            return new SettingModel
            {
                Json = text
            };
        }

        public SettingModel Update(SettingModel setting)
        {
            var filePath = Path.Combine(_appSettingsManagerOptions.AppSettingsFilePath, _appSettingsManagerOptions.AppSettingsFileName);
            System.IO.File.WriteAllText(filePath, setting.Json);

            _repository.Create(new Setting
            {
                Json = setting.Json,
                UpdatedDateTime = DateTime.UtcNow
            });

            return setting;
        }
    }
}
