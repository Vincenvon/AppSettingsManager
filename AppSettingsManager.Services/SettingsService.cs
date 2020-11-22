using AppSettingsManager.DataAccess;
using AppSettingsManager.Entities;
using AppSettingsManager.Requests;
using AppSettingsManager.Responses;

using System;
using System.IO;

namespace AppSettingsManager.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly Settings.Settings _appSettingsManagerOptions;

        private readonly IRepository<Setting> _repository;

        public SettingsService(IRepository<Setting> repository, Settings.Settings appSettingsManagerOptions)
        {
            _repository = repository;
            _appSettingsManagerOptions = appSettingsManagerOptions;
        }

        public SettingResponse Read()
        {
            var filePath = Path.Combine(_appSettingsManagerOptions.FileSettings.FilePath, _appSettingsManagerOptions.FileSettings.FileName);
            using (var stream = File.OpenRead(filePath))
            using (var streamReader = new StreamReader(stream))
            //using (var fileReader = new JsonTextReader(streamReader))
            {
                // TODO :: EXCLUDE HERE
                return new SettingResponse
                {
                    Json = streamReader.ReadToEnd()
                };
            }
        }

        public SettingResponse Update(SettingRequest setting)
        {
            var filePath = Path.Combine(_appSettingsManagerOptions.FileSettings.FilePath, _appSettingsManagerOptions.FileSettings.FileName);
            System.IO.File.WriteAllText(filePath, setting.Json);

            _repository.Create(new Setting
            {
                Json = setting.Json,
                UpdatedDateTime = DateTime.UtcNow
            });

            return new SettingResponse
            {
                Json = setting.Json
            };
        }
    }
}
