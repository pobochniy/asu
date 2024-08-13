using Api.Middleware;
using Atheneum.Dto.User;
using Atheneum.Entity;
using Atheneum.Enums;
using Atheneum.Extentions.Auth;
using Atheneum.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UsersController : Controller
    {
        private readonly UsersService _service;

        public UsersController(UsersService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<Profile>> GetProfiles()
        {
            var res = await _service.GetProfiles();
            return res;
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<RoleEnum>> GetRoles(Guid userId)
        {
            var res = await _service.GetRoles(userId);

            return res;
        }

        [HttpPost]
        [AuthorizeRoles(RoleEnum.roleManagement)]
        public async Task SetRoles([FromBody] UserAndRolesDto dto)
        {
            await _service.SetRoles(dto.UserId, dto.Roles);
        }
    }
}