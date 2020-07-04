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
        private readonly string _connectionString;

        public SettingsRepository(string dbFilePath, string dbFileName)
        {
            var dbPath = Path.Combine(dbFilePath, dbFileName);

            _connectionString = $"Filename={dbPath}; Connection=shared";
        }

        public IEnumerable<Setting> Read()
        {
            using (var liteDatabase = this.GetLiteDatabase())
            {
                return liteDatabase.GetCollection<Setting>().FindAll();
            }
        }

        public IEnumerable<Setting> Read(Expression<Func<Setting, bool>> expression, int skip, int limit)
        {
            using (var liteDatabase = this.GetLiteDatabase())
            {
                return liteDatabase.GetCollection<Setting>().Find(expression, skip, limit);
            }
        }

        public IEnumerable<Setting> Read(Query query, int skip, int limit)
        {
            using (var liteDatabase = this.GetLiteDatabase())
            {
                var collection = liteDatabase.GetCollection<Setting>();

                if (query.OrderBy != null && query.OrderBy.Fields != null)
                {
                    foreach (var field in query.OrderBy.Fields)
                    {
                        collection.EnsureIndex(field, $"$.{field}");
                    }
                }
                return collection.Find(query, skip, limit);
            }
        }

        public Setting Create(Setting setting)
        {
            using (var liteDatabase = this.GetLiteDatabase())
            {
                setting.Id = liteDatabase.GetCollection<Setting>().Insert(setting).AsInt32;
                return setting;
            }
        }

        public int Count(Query query)
        {
            using (var liteDatabase = this.GetLiteDatabase())
            {
                return liteDatabase.GetCollection<Setting>().Count(query);
            }
        }

        private ILiteDatabase GetLiteDatabase()
        {
            return new LiteDatabase(_connectionString);
        }
    }
}