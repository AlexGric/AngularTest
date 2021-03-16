using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace web_basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
       Business.Domain.Dog domain;

        public DogController(IConfiguration configuration) 
        {
            this.domain = new Business.Domain.Dog(configuration);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var dogs = this.domain.Get();
            return Ok(dogs);
        }
    }
}
