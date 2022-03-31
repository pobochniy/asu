using Api.Middleware;
using Atheneum.Dto.Issue;
using Atheneum.Interface;
using Microsoft.AspNetCore.Mvc;
using Atheneum.Enums;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class IssueController : Controller
    {
        private readonly IIssue service;

        public IssueController(IIssue service)
        {
            this.service = service;
        }

        [HttpPost]
        [AuthorizeRoles(RoleEnum.issueCrud)]
        public async Task<IActionResult> Create([FromBody] IssueDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var id = await service.Create(model);
            return Ok(id);
        }

        [HttpPost]
        [AuthorizeRoles(RoleEnum.issueCrud)]
        public async Task<IActionResult> Delete(long id)
        {
            await service.Delete(id);
            return Ok(id);
        }

        [HttpGet]
        [AuthorizeRoles(RoleEnum.issueRead, RoleEnum.issueCrud)]
        public async Task<IssueDto> Details(long id)
        {
            return await service.Details(id);
        }

        [HttpGet]
        [AuthorizeRoles(RoleEnum.issueRead, RoleEnum.issueCrud)]
        public async Task<IEnumerable<IssueDto>> GetList(long? epicId)
        {
            return await service.GetList(epicId);
        }

        [HttpPost]
        [AuthorizeRoles(RoleEnum.issueCrud)]
        public async Task<IActionResult> Update([FromBody] IssueDto issue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await service.Update(issue);

            var res = await service.Details(issue.Id);
            return Ok(res);
        }
    }
}