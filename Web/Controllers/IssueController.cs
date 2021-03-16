using System;
using Atheneum.Dto.Issue;
using Atheneum.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Delete(long id)
        {
            await service.Delete(id);
            return Ok(id);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IssueDto> Details(long id)
        {
            return await service.Details(id);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<IssueDto>> GetList(long? epicId)
        {
            return await service.GetList(epicId);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody]IssueDto issuedto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await service.Update(issuedto);

            var res = await service.Details(issuedto.Id);
            return Ok(res);
        }
    }
}

