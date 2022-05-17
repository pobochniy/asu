using Api.Middleware;
using Atheneum.Dto.Epic;
using Atheneum.Enums;
using Atheneum.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class EpicController : ControllerBase
    {
        private readonly IEpicService _service;

        public EpicController(IEpicService context)
        {
            _service = context;
        }

        [HttpGet]
        [Produces(typeof(EpicDto))]
        [AuthorizeRoles(RoleEnum.epicCrud, RoleEnum.epicRead)]
        public async Task<IActionResult> Details([FromQuery] int id)
        {
            try
            {
                var res = await _service.Details(id);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.GetType()}: {e.Message}");
            }
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<EpicDto>))]
        [AuthorizeRoles(RoleEnum.epicCrud, RoleEnum.epicRead)]
        public async Task<IEnumerable<EpicDto>> GetList()
        {
            return await _service.GetList();
        }

        [HttpPost]
        [Produces(typeof(int))]
        [AuthorizeRoles(RoleEnum.epicCrud)]
        public async Task<IActionResult> Create([FromBody] EpicDto epicDto)
        {
            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);

            var id = await _service.Create(epicDto);
            return Ok(id);
        }

        [HttpPost]
        [AuthorizeRoles(RoleEnum.epicCrud)]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            await _service.Delete(id);

            return Ok();
        }

        [HttpPost]
        [Produces(typeof(EpicDto))]
        [AuthorizeRoles(RoleEnum.epicCrud)]
        public async Task<IActionResult> Update([FromBody] EpicDto epicDto)
        {
            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);

            await _service.Update(epicDto);

            var res = await _service.Details(epicDto.Id);
            return Ok(res);
        }
    }
}