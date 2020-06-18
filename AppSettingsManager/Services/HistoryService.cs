using AppSettingsManager.DataAccess;
using AppSettingsManager.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppSettingsManager.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IRepository<Setting> _settingRepository;

        public HistoryService(IRepository<Setting> settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public ICollection<Setting> Read()
        {
            return _settingRepository.Read().ToList();
        }
    }
}
