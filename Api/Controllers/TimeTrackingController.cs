using Atheneum.Dto.TimeTracking;
using Atheneum.Extentions.Auth;
using Atheneum.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class TimeTrackingController : ControllerBase
    {
        private readonly ITimeTracking _service;

        public TimeTrackingController(ITimeTracking context)
        {
            this._service = context;
        }

        [HttpGet]
        public async Task<TimeTrackingDto> Details([FromQuery] long id)
        {
            var res = await _service.Details(id);
            return res;
        }

        [HttpGet]
        public async Task<IEnumerable<TimeTrackingDto>> GetList()
        {
            return await _service.GetList();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TimeTrackingDto timeTracking)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            timeTracking.UserId = HttpContext.User.GetUserId();

            var id = await _service.Create(timeTracking);
            return Ok(id);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] long id)
        {
            await _service.Delete(id);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] TimeTrackingDto timeTracking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            timeTracking.UserId = HttpContext.User.GetUserId();
            await _service.Update(timeTracking);

            var res = await _service.Details(timeTracking.Id.Value);
            return Ok(res);
        }
    }
}