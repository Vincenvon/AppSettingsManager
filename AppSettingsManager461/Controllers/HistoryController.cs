using AppSettingsManager.DataAccess;
using AppSettingsManager.Requests;
using AppSettingsManager.Services;

using System.Web.Http;

namespace AppSettingsManager461.Controllers
{
    [Route("api/[controller]")]
    public class HistoryController : ApiController
    {
        private readonly IHistoryService _historyService;

        public HistoryController()
        {
            var setting = SettingsProvider.Setting;
            _historyService = new HistoryService(new SettingsRepository(setting.DbFilePath, setting.DbFileName));
        }

        [HttpPost]
        public IHttpActionResult Read([FromBody]GridRequest gridRequestModel)
        {
            var data = _historyService.Read(gridRequestModel);
            return Ok(data);
        }
    }
}
