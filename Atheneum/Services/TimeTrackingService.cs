using Atheneum.Dto.TimeTracking;
using Atheneum.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atheneum.Entity;

namespace Atheneum.Services
{
    public class TimeTrackingService
    {
        private readonly ApplicationContext _db;

        public TimeTrackingService(ApplicationContext context)
        {
            _db = context;
        }

        public async Task<long> Create(TimeTrackingDto dto)
        {
            var timeTracking = new TimeTracking
            {
                CreateDate = DateTime.Now,
                Date = dto.Date.Value,
                From = dto.From.Value,
                To = dto.To.Value,
                Comment = dto.Comment,
                UserId = dto.UserId.Value,
                IssueId = dto.IssueId,
                EpicId = dto.EpicId
            };
            await _db.TimeTracking.AddAsync(timeTracking);
            await _db.SaveChangesAsync();
            return timeTracking.Id;
        }

        public async Task<TimeTrackingDto> Details(long id)
        {
            var timeTracking = await _db.TimeTracking.FindAsync(id);
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
            var timeTracking = await _db.TimeTracking.FindAsync(timeTrackingDto.Id);
            if (timeTracking.UserId != timeTrackingDto.UserId)
            {
                throw new InvalidOperationException("Возможно редактирование только своих задач");
            }

            timeTracking.Date = timeTrackingDto.Date.Value;
            timeTracking.From = timeTrackingDto.From.Value;
            timeTracking.To = timeTrackingDto.To.Value;
            timeTracking.Comment = timeTrackingDto.Comment;
            timeTracking.UserId = timeTrackingDto.UserId.Value;
            timeTracking.IssueId = timeTrackingDto.IssueId;
            timeTracking.EpicId = timeTrackingDto.EpicId;

            await _db.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var i = await _db.TimeTracking.FindAsync(id);
            _db.TimeTracking.Remove(i);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<TimeTrackingDto>> GetList(Guid? userId, DateOnly? from = null, DateOnly? to = null)
        {
            from ??= DateOnly.FromDateTime(DateTime.Now.AddDays(-7));
            var query = _db.TimeTracking.AsQueryable();

            if (userId.HasValue) query = query.Where(x => x.UserId == userId);
            query = query.Where(x => x.Date >= from.Value);
            if (userId.HasValue) query = query.Where(x => x.Date <= to.Value);

            var timeTracking = await query
                .Select(x => new TimeTrackingDto
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