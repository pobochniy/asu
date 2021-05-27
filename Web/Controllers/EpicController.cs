using Atheneum.Dto.Epic;
using Atheneum.Enums;
using Atheneum.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Middleware;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpicController : Controller
    {
        private readonly IEpic service;

        public EpicController(IEpic context)
        {
            this.service = context;
        }

        [HttpGet("[action]")]
        [AuthorizeRoles(RoleEnum.epicCrud, RoleEnum.epicRead)]
        public async Task<EpicDto> Details([FromQuery]int id)
        {
            var res = await service.Details(id);
            return res;
        }

        [HttpGet("[action]")]
        [AuthorizeRoles(RoleEnum.epicCrud, RoleEnum.epicRead)]
        public async Task<IEnumerable<EpicDto>> GetList()
        {
            return await service.GetList();
        }

        [HttpPost("[action]")]
        [AuthorizeRoles(RoleEnum.epicCrud)]
        public async Task<IActionResult> Create([FromBody] EpicDto epicDto)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            else
            {
                var id = await service.Create(epicDto);
                return Ok(id);
            }
        }

        [HttpPost("[action]")]
        [AuthorizeRoles(RoleEnum.epicCrud)]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            await service.Delete(id);

            return Ok();
        }

        [HttpPost("[action]")]
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