using AppSettingsManager.Entities;

using LiteDB;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;

namespace AppSettingsManager.DataAccess
{
    public class Repository<T>: IRepository<T> where T: Entity
    {
        private readonly string _connectionString;

        public Repository(string dbFilePath, string dbFileName)
        {
            var dbPath = Path.Combine(dbFilePath, dbFileName);

            _connectionString = $"Filename={dbPath}; Connection=shared";
        }

        public IEnumerable<T> Read()
        {
            using (var liteDatabase = this.GetLiteDatabase())
            {
                return liteDatabase.GetCollection<T>().FindAll();
            }
        }

        public IEnumerable<T> Read(Expression<Func<T, bool>> expression)
        {
            using (var liteDatabase = this.GetLiteDatabase())
            {
                return liteDatabase.GetCollection<T>().Find(expression);
            }
        }

        public IEnumerable<T> Read(Expression<Func<T, bool>> expression, int skip, int limit)
        {
            using (var liteDatabase = this.GetLiteDatabase())
            {
                return liteDatabase.GetCollection<T>().Find(expression, skip, limit);
            }
        }

        public IEnumerable<T> Read(Query query, int skip, int limit)
        {
            using (var liteDatabase = this.GetLiteDatabase())
            {
                var collection = liteDatabase.GetCollection<T>();

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

        public T Create(T setting)
        {
            using (var liteDatabase = this.GetLiteDatabase())
            {
                setting.Id = liteDatabase.GetCollection<T>().Insert(setting).AsInt32;
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
