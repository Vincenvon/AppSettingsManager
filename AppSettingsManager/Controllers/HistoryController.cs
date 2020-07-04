using AppSettingsManager.Entities;
using AppSettingsManager.Requests;
using AppSettingsManager.Services;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppSettingsManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoryController : Controller
    {
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpPost]
        public IActionResult Read([FromBody]GridRequest gridRequestModel)
        {
            var data = _historyService.Read(gridRequestModel);
            return Ok(data);
        }
    }
}
