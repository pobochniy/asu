using Atheneum.Dto.TimeTracking;
using Atheneum.Entity.Identity;
using Atheneum.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atheneum.Service
{
    public class TimeTrackingService: ITimeTracking
    {
        private ApplicationContext db;

        public TimeTrackingService(ApplicationContext context)
        {
            db = context;
        }

        public async Task<long> Create(TimeTrackingDto dto)
        {
            var timeTracking = new TimeTracking
            {
                Date = dto.Date,
                From = dto.From.Value,
                To = dto.To.Value,
                Comment = dto.Comment,
                UserId = dto.UserId,
                IssueId = dto.IssueId,
                EpicId = dto.EpicId
            };
            await db.TimeTracking.AddAsync(timeTracking);
            await db.SaveChangesAsync();
            return timeTracking.Id;
        }

        public async Task<TimeTrackingDto> Details(long id)
        {
            var timeTracking = await db.TimeTracking.FindAsync(id);
            var timeTrackingDto = new TimeTrackingDto
            {
                Id = timeTracking.Id,
                Date = timeTracking.Date,
                From = timeTracking.From,
                To = timeTracking.To,
                Comment = timeTracking.Comment,
                UserId = timeTracking.UserId,
                IssueId = timeTracking.IssueId,
                EpicId = timeTracking.EpicId
            };
            return timeTrackingDto;
        }

        public async Task Update(TimeTrackingDto timeTrackingDto)
        {
            var timeTracking = await db.TimeTracking.FindAsync(timeTrackingDto.Id);
            timeTracking.Id = timeTrackingDto.Id;
            timeTracking.Date = timeTrackingDto.Date;
            timeTracking.From = timeTrackingDto.From.Value;
            timeTracking.To = timeTrackingDto.To.Value;
            timeTracking.Comment = timeTrackingDto.Comment;
            timeTracking.UserId = timeTrackingDto.UserId;
            timeTracking.IssueId = timeTrackingDto.IssueId;
            timeTracking.EpicId = timeTrackingDto.EpicId;

            await db.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var i = await db.TimeTracking.FindAsync(id);
            db.TimeTracking.Remove(i);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<TimeTrackingDto>> GetList()
        {
            var timeTracking = await db.TimeTracking.Select(x => new TimeTrackingDto
            {
                Id = x.Id,
                Date = x.Date,
                From = x.From,
                To = x.To,
                Comment = x.Comment,
                UserId = x.UserId,
                IssueId = x.IssueId,
                EpicId = x.EpicId
            }).ToArrayAsync();
            return timeTracking;
        }

    }
}
