using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atheneum.Dto.User;
using Atheneum.Entity.Identity;
using Atheneum.Enums;
using Atheneum.Interface;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<RoleEnum>> GetRoles(Guid userId)
        {
            var res = await service.GetRoles(userId);

            return res;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task SetRoles([FromBody]UserAndRolesDto dto)
        {
            await service.SetRoles(dto.UserId, dto.Roles);
        }


    }
}
