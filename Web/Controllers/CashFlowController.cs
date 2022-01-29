using Atheneum.Dto.CashFlow;
using Atheneum.Extentions.Auth;
using Atheneum.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CashFlowController : Controller
    {
        private readonly ICashFlow service;

        public CashFlowController(ICashFlow context)
        {
            this.service = context;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Details([FromQuery] Guid id)
        {
            var res = await service.Details(id);
            return Ok(res);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList(Guid? userId)
        {
            var res = await service.GetList(userId);
            return Ok(res);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CashFlowDto dto)
        {
            dto.UserIdPassed = User.GetUserId();
            //dto.UserIdPassed = new Guid("4B1908E2-E4F4-4796-DC14-08D9E3364177");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    var id = await service.Create(dto);
                    return Ok(id);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }
    }
}
