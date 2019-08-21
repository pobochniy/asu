using Atheneum.Dto.Auth;
using Atheneum.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]")]

    public class IssueController : Controller
    {
        private readonly IIssue service;

        public IssueController(IIssue service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create([FromBody]IssueDto model)
        {
            if (ModelState.IsValid)
            {
                var id = await service.Create(model);

                return Ok(id);
            }

            return BadRequest(ModelState);
        }
    }
}

