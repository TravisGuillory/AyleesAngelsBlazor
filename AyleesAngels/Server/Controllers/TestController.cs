using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AyleesAngels.Shared.Models;
using AyleesAngels.Shared.Utils;
using AyleesAngels.Server.Services;

namespace AyleesAngels.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TestController : Controller
    {
        private readonly IPartnerService _service;

        public TestController(IPartnerService service)
        {
            _service = service;
        }


        [HttpGet]
        [AllowAnonymous]
        
        public async Task<IActionResult> Get()
        {

            //return Ok(await _service.GetPartners());

            return Ok("Kiss my ass");
        }
    }

    
}
