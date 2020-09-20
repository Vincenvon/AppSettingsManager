using AppSettingsManager.Requests;
using AppSettingsManager.Services;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Text;

namespace AppSettingsManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IUserManager _userManager;

        public LoginController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public IActionResult Index([FromBody] LoginRequest loginRequest)
        {
            return Ok(_userManager.Login(loginRequest));
        }
    }
}
