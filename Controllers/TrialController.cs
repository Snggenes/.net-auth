using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_new.Extensions;
using dotnet_new.Mappers;
using dotnet_new.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_new.Controllers
{
    [Route("trial")]
    [ApiController]
    public class TrialController : ControllerBase
    {

        private readonly UserManager<AppUser> _userManager;

        public TrialController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var userid = User.GetUserId();

            Console.WriteLine(userid);

            return Ok(new { message = "Hello World" });
        }
    }
}