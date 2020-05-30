using AppSettingsManager.Services;

using Microsoft.AspNetCore.Mvc;

namespace AppSettingsManager.Controllers
{
    [ApiController]
    public class SettingsController: Controller
    {
        private readonly ISettingsService _settingsService;

        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "appsettings.json");
        //    var text = await System.IO.File.ReadAllTextAsync(filePath);

        //    return View(new Model
        //    {
        //        Json = text
        //    });
        //}

        //[HttpPost]
        //public async Task<IActionResult> Post(Model model)
        //{
        //    var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "appsettings.json");
        //    await System.IO.File.WriteAllTextAsync(filePath, model.Json);
        //    return Ok();
        //}
    }
}
