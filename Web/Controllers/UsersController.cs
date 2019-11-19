using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atheneum.Entity.Identity;
using Atheneum.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUsersService service;

        public UsersController(IUsersService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<Profile>> GetProfiles() 
        {
            var res = await service.GetProfiles();
            return res;
        }
    }
}
