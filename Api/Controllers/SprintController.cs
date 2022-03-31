using Api.Middleware;
using Atheneum.Dto.Sprint;
using Atheneum.Enums;
using Atheneum.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SprintController : Controller
    {
        private readonly ISprint service;

        public SprintController(ISprint service)
        {
            this.service = service;
        }

        [HttpGet]
        [AuthorizeRoles(RoleEnum.sprintCrud, RoleEnum.epicRead)]
        public async Task<IEnumerable<SprintDto>> GetList()
        {
            return await service.GetList();
        }

        [HttpPost]
        [AuthorizeRoles(RoleEnum.sprintCrud)]
        public async Task<IActionResult> Create([FromBody] SprintDto model)
        {
            // TODO: Вынести валидацию в модель 
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var id = await service.Create(model);
                return Ok(id);
            }
            catch (ArgumentException)
            {
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [AuthorizeRoles(RoleEnum.sprintCrud)]
        public async Task<IActionResult> Delete(long id)
        {
            await service.Delete(id);
            return Ok(id);
        }

        [HttpGet]
        [AuthorizeRoles(RoleEnum.sprintCrud, RoleEnum.sprintRead)]
        public async Task<SprintDto> Details(long id)
        {
            return await service.Details(id);
        }

        [HttpPost]
        [AuthorizeRoles(RoleEnum.sprintCrud)]
        public async Task<IActionResult> Update([FromBody] SprintDto issue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await service.Update(issue);

            var res = await service.Details(issue.Id);
            return Ok(res);
        }

        [HttpGet]
        [AuthorizeRoles(RoleEnum.sprintCrud)]
        public async Task<IActionResult> AddIssue(long sprintId, long issueId)
        {
            await service.AddIssue(sprintId, issueId);
            return Ok(sprintId);
        }

        [HttpGet]
        [AuthorizeRoles(RoleEnum.sprintCrud)]
        public async Task<IActionResult> DeleteIssue(long sprintId, long issueId)
        {
            await service.DeleteIssue(sprintId, issueId);
            return Ok(sprintId);
        }
    }
}