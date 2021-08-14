using Atheneum.Dto.TimeTracking;
using Atheneum.Extentions.Auth;
using Atheneum.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TimeTrackingController : Controller
    {
        private readonly ITimeTracking service;

        public TimeTrackingController(ITimeTracking context)
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
            timeTrackingDto.UserId = HttpContext.User.GetUserId();
            return Ok(timeTrackingDto);
            //if (ModelState.IsValid)
            //{
            //    var id = await service.Create(timeTrackingDto);
            //    return Ok(id);
            //}

            //return BadRequest(ModelState);
   
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Delete([FromBody] long id)
        {
            await service.Delete(id);

            return Ok();
        }

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

        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<TaskItemDto>> GetUserTasks()
        {
            var UserId = HttpContext.User.GetUserId();
            var res = await service.GetUserEpicsIssues(UserId);
            return res;
        }
    }
}