using Atheneum.Dto.Sprint;
using Atheneum.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class SprintController : Controller
    {
        private readonly ISprint service;

        public SprintController(ISprint service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<SprintDto>> GetList()
        {
            return await service.GetList();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create([FromBody] SprintDto model)
        {
            if (ModelState.IsValid)
            {
                var id = await service.Create(model);

                return Ok(id);
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Delete(long id)
        {
            await service.Delete(id);
            return Ok(id);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<SprintDto> Details(long id)
        {
            return await service.Details(id);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody] SprintDto issuedto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await service.Update(issuedto);

            var res = await service.Details(issuedto.Id);
            return Ok(res);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddIssue(long sprintId, long issueId)
        {
            await service.AddIssue(sprintId, issueId);
            return Ok(sprintId);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DeleteIssue(long sprintId, long issueId)
        {
            await service.DeleteIssue(sprintId, issueId);
            return Ok(sprintId);
        }
    }
}
