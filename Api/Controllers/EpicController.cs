using Api.Middleware;
using Atheneum.Dto.Epic;
using Atheneum.Enums;
using Atheneum.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EpicController : Controller
    {
        private readonly IEpic service;

        public EpicController(IEpic context)
        {
            this.service = context;
        }

        [HttpGet]
        [AuthorizeRoles(RoleEnum.epicCrud, RoleEnum.epicRead)]
        public async Task<EpicDto> Details([FromQuery] int id)
        {
            var res = await service.Details(id);
            return res;
        }

        [HttpGet]
        [AuthorizeRoles(RoleEnum.epicCrud, RoleEnum.epicRead)]
        public async Task<IEnumerable<EpicDto>> GetList()
        {
            return await service.GetList();
        }

        [HttpPost]
        [AuthorizeRoles(RoleEnum.epicCrud)]
        public async Task<IActionResult> Create([FromBody] EpicDto epicDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = await service.Create(epicDto);
            return Ok(id);
        }

        [HttpPost]
        [AuthorizeRoles(RoleEnum.epicCrud)]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            await service.Delete(id);

            return Ok();
        }

        [HttpPost]
        [AuthorizeRoles(RoleEnum.epicCrud)]
        public async Task<IActionResult> Update([FromBody] EpicDto epicDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await service.Update(epicDto);

            var res = await service.Details(epicDto.Id);
            return Ok(res);
        }
    }
}