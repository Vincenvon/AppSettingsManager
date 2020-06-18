using AppSettingsManager.Entity;

using LiteDB;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppSettingsManager.DataAccess
{
    public class SettingsRepository: IRepository<Setting>
    {
        private readonly ILiteDatabase _liteDatabase;

        public SettingsRepository(ILiteDatabase liteDatabase)
        {
            _liteDatabase = liteDatabase;
        }

        public IEnumerable<Setting> Read()
        {
            return _liteDatabase.GetCollection<Setting>().FindAll();
        }

        public Setting Create(Setting setting)
        {
            setting.Id = _liteDatabase.GetCollection<Setting>().Insert(setting).AsInt32;
            return setting;
        }
    }
}