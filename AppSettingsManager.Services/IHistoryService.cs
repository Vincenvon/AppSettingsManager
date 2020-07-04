using AppSettingsManager.Entities;
using AppSettingsManager.Requests;
using AppSettingsManager.Responses;

namespace AppSettingsManager.Services
{
    public interface IHistoryService
    {
        GridResponse<Setting> Read(GridRequest gridRequestModel);
    }
}
