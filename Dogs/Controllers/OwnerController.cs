using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Dogs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private Business.Domain.Dog dogDomain;
        private Business.Domain.Owner ownerDomain;
        private Business.Domain.Account accountDomain;
        private int UserId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public OwnerController(IConfiguration configuration)
        {
            this.dogDomain = new Business.Domain.Dog(configuration);
            this.ownerDomain = new Business.Domain.Owner(configuration);
            this.accountDomain = new Business.Domain.Account(configuration);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        [Route("")]
        public IActionResult GetPets()
        {
            if (!ownerDomain.Get().Any(owner => owner.UserId == UserId))
            {
                return Ok(Enumerable.Empty<Business.ViewModels.Dog>());
            }

            var dogsOwner = ownerDomain.Get().Where(owner => owner.UserId == UserId);
            var dogs = dogDomain.Get().Where(dog => dogsOwner.Any(owner => owner.DogId == dog.Id));

            return Ok(dogs);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("")]
        public IActionResult GetUsers()
        {           
            var users = accountDomain.Get().ToList();            
            return Ok(users);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("")]
        public IActionResult SetOwnersRole(Business.ViewModels.Role role, int userId)
        {
            accountDomain.SetRole(userId, role);            
            return Ok();
        }
    }
}
