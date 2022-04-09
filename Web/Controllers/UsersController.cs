using Web.Middleware;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<UserEditDto> Details([FromQuery] Guid id)
        {
            return await service.Details(id);
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize]
        public async Task<IActionResult> Edit([FromBody] UserEditDto userdto)
        {
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }*/

            userdto.Id = HttpContext.User.GetUserId();

            await service.Edit(userdto);

            var res = await service.Details(HttpContext.User.GetUserId());
            return Ok(res);
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize]
        public async Task<IActionResult> ChangeAvatar([FromBody] byte[] img)
        {
            await service.SetAvatar(HttpContext.User.GetUserId(), img);

            return Ok();
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
