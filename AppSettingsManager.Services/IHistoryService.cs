using AppSettingsManager.Requests;
using AppSettingsManager.Responses;

namespace AppSettingsManager.Services
{
    public interface IHistoryService
    {
        GridResponse<SettingHistoryResponse> Read(GridRequest gridRequestModel);
    }
}
