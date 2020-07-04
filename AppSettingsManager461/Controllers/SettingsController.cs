using AppSettingsManager.DataAccess;
using AppSettingsManager.Requests;
using AppSettingsManager.Services;

using System.Web.Http;

namespace AppSettingsManager461.Controllers
{
    [Route("api/[controller]")]
    public class SettingsController : ApiController
    {
        private readonly ISettingsService _settingsService;

        public SettingsController()
        {
            var setting = SettingsProvider.Setting;
            _settingsService = new SettingsService(new SettingsRepository(setting.DbFilePath, setting.DbFileName), setting);
        }

        [HttpGet]
        public IHttpActionResult Read()
        {
            return Ok(_settingsService.Read());
        }

        [HttpPost]
        public IHttpActionResult Update(SettingRequest model)
        {
            return Ok(_settingsService.Update(model));
        }
    }
}
