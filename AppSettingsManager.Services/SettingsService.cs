using AppSettingsManager.DataAccess;
using AppSettingsManager.Entities;
using AppSettingsManager.Requests;
using AppSettingsManager.Responses;

using Newtonsoft.Json;

using System;
using System.IO;

namespace AppSettingsManager.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly Settings.Settings _appSettingsManagerOptions;

        private readonly Settings.FileContentSettings _fileContentSettings;

        private readonly IRepository<Setting> _repository;

        public SettingsService(
            IRepository<Setting> repository,
            Settings.Settings appSettingsManagerOptions,
            Settings.FileContentSettings fileContentSettings)
        {
            _repository = repository;
            _appSettingsManagerOptions = appSettingsManagerOptions;
            _fileContentSettings = fileContentSettings;
        }

        public SettingResponse Read()
        {
            var filePath = Path.Combine(_appSettingsManagerOptions.FileSettings.FilePath, _appSettingsManagerOptions.FileSettings.FileName);
            using (var stream = File.OpenRead(filePath))
            using (var streamReader = new StreamReader(stream))
            using (var fileReader = new JsonTextReader(streamReader))
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

        public string IncludeExclude(JsonTextReader jsonTextReader)
        {
            while (jsonTextReader.Read())
            {
                var token = jsonTextReader.Value;
            }
        }
    }
}
