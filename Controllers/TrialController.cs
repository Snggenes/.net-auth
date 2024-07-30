using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_new.Controllers
{
    [Route("trial")]
    [ApiController]
    public class TrialController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(new { message = "This is a trial endpoint" });
        }
    }
}