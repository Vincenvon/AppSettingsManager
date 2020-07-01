using AppSettingsManager.Entities;

using LiteDB;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;

namespace AppSettingsManager.DataAccess
{
    public class SettingsRepository : IRepository<Setting>
    {
        private readonly ILiteDatabase _liteDatabase;

        public SettingsRepository(string dbFilePath, string dbFileName)
        {
            var dbPath = Path.Combine(dbFilePath, dbFileName);

            _liteDatabase = new LiteDatabase(dbPath);
        }

        public IEnumerable<Setting> Read()
        {
            return _liteDatabase.GetCollection<Setting>().FindAll();
        }

        public IEnumerable<Setting> Read(Expression<Func<Setting, bool>> expression, int skip, int limit)
        {
            return _liteDatabase.GetCollection<Setting>().Find(expression, skip, limit);
        }

        public IEnumerable<Setting> Read(Query query, int skip, int limit)
        {
            var collection = _liteDatabase.GetCollection<Setting>();

            if (query.OrderBy != null && query.OrderBy.Fields != null)
            {
                foreach (var field in query.OrderBy.Fields)
                {
                    collection.EnsureIndex(field, $"$.{field}");
                }
            }
            return collection.Find(query, skip, limit);
        }

        public Setting Create(Setting setting)
        {
            setting.Id = _liteDatabase.GetCollection<Setting>().Insert(setting).AsInt32;
            return setting;
        }

        public int Count(Query query)
        {
            return _liteDatabase.GetCollection<Setting>().Count(query);
        }
    }
}