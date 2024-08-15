using Atheneum.Dto.TimeTracking;
using Atheneum.Extentions.Auth;
using Atheneum.Interface;
using Atheneum.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class TimeTrackingController : ControllerBase
    {
        private readonly TimeTrackingService _service;

        public TimeTrackingController(TimeTrackingService context)
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

        [HttpGet]
        public async Task<IEnumerable<UserTimeTrackingDto>> UserTracking()
        {
            var timeTracks = await _service.GetList();

            var res = timeTracks
                .GroupBy(t => t.Date,
                    t => t,
                    (k, v) => new UserTimeTrackingDto
                    {
                        Date = k.Value,
                        TimeTracks = v.Select(x => new TimeTracksDto
                        {
                            From = x.From.Value,
                            To = x.To.Value,
                            Comment = x.Comment,
                            IssueId = x.IssueId,
                            EpicId = x.EpicId
                        }).ToArray()
                    });
            return res;
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