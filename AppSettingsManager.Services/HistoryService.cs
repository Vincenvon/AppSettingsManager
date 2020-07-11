using AppSettingsManager.DataAccess;
using AppSettingsManager.Entities;
using AppSettingsManager.Requests;
using AppSettingsManager.Responses;

using LiteDB;

using System;
using System.Linq;

namespace AppSettingsManager.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IRepository<Setting> _settingRepository;

        public HistoryService(IRepository<Setting> settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public GridResponse<SettingHistoryResponse> Read(GridRequest gridRequestModel)
        {
            Query query = null;

            if (gridRequestModel.Sort != null 
                && !string.IsNullOrEmpty(gridRequestModel.Sort.Name)
                && !string.IsNullOrEmpty(gridRequestModel.Sort.Direction))
            {
                var order = gridRequestModel.Sort.Direction.Equals("desc", StringComparison.OrdinalIgnoreCase) ? Query.Descending :
                    Query.Ascending;

                query = Query.All(gridRequestModel.Sort.Name, order);
            }

            query = query ?? Query.All();

            return new GridResponse<SettingHistoryResponse>
            {
                Data = _settingRepository.Read(query, gridRequestModel.Page - 1, gridRequestModel.PageSize)
                .Select(h => new SettingHistoryResponse {
                    Id = h.Id,
                    Json = h.Json,
                    UpdatedDateTime = h.UpdatedDateTime
                }).ToArray(),
                Total = _settingRepository.Count(query)
            };
        }
    }
}
