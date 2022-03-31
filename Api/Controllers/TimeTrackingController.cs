using Atheneum.Dto.TimeTracking;
using Atheneum.Extentions.Auth;
using Atheneum.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TimeTrackingController : Controller
    {
        private readonly ITimeTracking service;

        public TimeTrackingController(ITimeTracking context)
        {
            this.service = context;
        }

        [HttpGet]
        public async Task<TimeTrackingDto> Details([FromQuery] long id)
        {
            var res = await service.Details(id);
            return res;
        }

        [HttpGet]
        public async Task<IEnumerable<TimeTrackingDto>> GetList()
        {
            return await service.GetList();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TimeTrackingDto timeTracking)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            timeTracking.UserId = HttpContext.User.GetUserId();

            var id = await service.Create(timeTracking);
            return Ok(id);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] long id)
        {
            await service.Delete(id);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] TimeTrackingDto timeTracking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await service.Update(timeTracking);

            var res = await service.Details(timeTracking.Id);
            return Ok(res);
        }
    }
}