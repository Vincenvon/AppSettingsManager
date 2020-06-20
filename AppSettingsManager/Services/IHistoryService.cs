using AppSettingsManager.Entity;
using AppSettingsManager.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace AppSettingsManager.Services
{
    public interface IHistoryService
    {
        GridResponseModel<Setting> Read(GridRequestModel gridRequestModel);
    }
}
