using System;
using System.Collections.Generic;
using System.Text;

namespace AppSettingsManager.DataAccess
{
    public interface IRepository<T>
    {
        IEnumerable<T> Read();

        T Create(T setting);
    }
}
