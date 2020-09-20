using AppSettingsManager.Entities;

using LiteDB;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AppSettingsManager.DataAccess
{
    public interface IRepository<T> where T: Entity
    {
        IEnumerable<T> Read();

        IEnumerable<T> Read(Expression<Func<T, bool>> expression);

        IEnumerable<T> Read(Expression<Func<T, bool>> expression, int skip, int limit);

        IEnumerable<T> Read(Query query, int skip, int limit);

        int Count(Query query);

        T Create(T setting);
    }
}
