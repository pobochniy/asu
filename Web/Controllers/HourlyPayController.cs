using Atheneum.Dto.HourlyPay;
using Atheneum.Enums;
using Atheneum.Extentions.Auth;
using Atheneum.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Middleware;
using System;
namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HourlyPayController : Controller
    {
        private readonly IHourlyPay service;

        public HourlyPayController(IHourlyPay service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("[action]")]
        [AuthorizeRoles(RoleEnum.hourlyPayCrud)]
        public async Task<IActionResult> Create([FromBody] HourlyPayDto model)
        {
            try
            {
                model.UserIdCreated = User.GetUserId();

                if (ModelState.IsValid)
                {
                    var id = await service.Create(model);

                    return Ok(id);
                }
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }         
        }


        [HttpGet]
        [Route("[action]")]
        [AuthorizeRoles(RoleEnum.hourlyPayRead, RoleEnum.hourlyPayCrud)]
        public async Task<HourlyPayDto> Details(int id)
        {
            return await service.Details(id);
        }

        [HttpGet]
        [Route("[action]")]
        [AuthorizeRoles(RoleEnum.hourlyPayRead, RoleEnum.hourlyPayCrud)]
        public async Task<IEnumerable<HourlyPayDto>> GetList(Guid? userId)
        {
            return await service.GetList(userId);
        }

        /*[HttpPost]
        [Route("[action]")]
        //[AuthorizeRoles(RoleEnum.hourlyPayCrud)]
        public async Task<IActionResult> Update([FromBody] HourlyPayDto hourlyPaydto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await service.Update(hourlyPaydto);

            var res = await service.Details(hourlyPaydto.Id);
            return Ok(res);
        }*/
    }
}
