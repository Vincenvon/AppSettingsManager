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
        private readonly IRepository<Setting> _repository;

        public SettingsService(IRepository<Setting> repository)
        {
            _repository = repository;
        }

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

            _repository.Create(new Setting
            {
                Json = setting.Json,
                UpdatedDateTime = DateTime.UtcNow
            });

            return setting;
        }
    }
}
