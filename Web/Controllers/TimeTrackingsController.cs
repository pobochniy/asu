using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Atheneum.Entity.Identity;
using Atheneum.Interface;
using Atheneum.Dto.TimeTracking;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeTrackingsController : Controller
    {
        private readonly ITimeTracking service;

        public TimeTrackingsController(ITimeTracking context)
        {
            this.service = context;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<TimeTrackingDto> Details([FromQuery]long Id)
        {
            var res = await service.Details(Id);
            return res;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<TimeTrackingDto>> GetList()
        {
            return await service.GetList();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create([FromBody] TimeTrackingDto timeTrackingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var id = await service.Create(timeTrackingDto);
                return Ok(id);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Delete([FromBody] long id)
        {
            await service.Delete(id);

            return Ok();
        }

        // DELETE: api/TimeTrackings/5
        [HttpPost("[action]")]
        public async Task<IActionResult> Update([FromBody] TimeTrackingDto timeTrackingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await service.Update(timeTrackingDto);

            var res = await service.Details(timeTrackingDto.Id);
            return Ok(res);
        }
    }
}