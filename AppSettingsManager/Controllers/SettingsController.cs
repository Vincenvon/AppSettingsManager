using AppSettingsManager.Requests;
using AppSettingsManager.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppSettingsManager.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    public class SettingsController : Controller
    {
        private readonly ISettingsService _settingsService;

        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        [HttpGet]
        public IActionResult Read()
        {
            return Ok(_settingsService.Read());
        }

        [HttpPost]
        public IActionResult Update(SettingRequest model)
        {
            return Ok(_settingsService.Update(model));
        }
    }
}
