using AppSettingsManager.Entity;
using AppSettingsManager.Models;
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

        [HttpGet]
        public IActionResult Read()
        {
            var data = _historyService.Read();
            return Ok(new GridModel<Setting>
            {
                Data = data.ToArray(),
                Total = data.Count
            });
        }
    }
}
