using Atheneum.Dto.User;
using Atheneum.Entity.Identity;
using Atheneum.Enums;
using Atheneum.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Middleware;

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
        [Authorize]
        public async Task<IEnumerable<Profile>> GetProfiles()
        {
            var res = await service.GetProfiles();
            return res;
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<RoleEnum>> GetRoles(Guid userId)
        {
            var res = await service.GetRoles(userId);

            return res;
        }

        [HttpPost]
        [Route("[action]")]
        [AuthorizeRoles(RoleEnum.roleManagement)]
        public async Task SetRoles([FromBody] UserAndRolesDto dto)
        {
            await service.SetRoles(dto.UserId, dto.Roles);
        }
    }
}
