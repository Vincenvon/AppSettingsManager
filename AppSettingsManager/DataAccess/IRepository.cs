using LiteDB;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AppSettingsManager.DataAccess
{
    public interface IRepository<T>
    {
        IEnumerable<T> Read();

        IEnumerable<T> Read(Expression<Func<T, bool>> expression, int skip, int limit);

        IEnumerable<T> Read(Query query, int skip, int limit);

        int Count(Query query);

        T Create(T setting);
    }
}
