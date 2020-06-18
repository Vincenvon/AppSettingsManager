using AppSettingsManager.Entity;

using System;
using System.Collections.Generic;
using System.Text;

namespace AppSettingsManager.Services
{
    public interface IHistoryService
    {
        ICollection<Setting> Read(); 
    }
}
