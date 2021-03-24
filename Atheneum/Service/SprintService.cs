using Atheneum.Dto.Issue;
using Atheneum.Dto.Sprint;
using Atheneum.Entity;
using Atheneum.Entity.Identity;
using Atheneum.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Atheneum.Entity.Sprint;

namespace Atheneum.Service
{
    public class SprintService : ISprint
    {
        private ApplicationContext db;

        public SprintService(ApplicationContext context)
        {
            db = context;
        }
        public async Task<IEnumerable<SprintDto>> GetList()
        {
            var sprints = await db.Sprint
                .Select(x => new SprintDto
                {
                    Id = x.Id,
                    StartDate = x.StartDate,
                    FinishtDate = x.FinishtDate,
                    IsEnded = x.IsEnded
                }).ToArrayAsync();

            return sprints;
        }

        public async Task<long> Create(SprintDto dto)
        {
            checkDate(dto);
            await checkSprintCrossAsync(dto);

            var sprint = new Sprint
            {
                StartDate = dto.StartDate,
                FinishtDate = dto.FinishtDate,
                IsEnded = 0
            };
            await db.Sprint.AddAsync(sprint);
            await db.SaveChangesAsync();

            return sprint.Id;
        }

        public async Task Delete(long Id)
        {
            await checkSprintHasIssues(Id);

            var sprint = await db.Sprint.SingleAsync(s => s.Id == Id);
            db.Sprint.Remove(sprint);

            await db.SaveChangesAsync();
        }

        public async Task<SprintDto> Details(long? id)
        {
            if (!id.HasValue) throw new ArgumentException("Сломано");

            if (id.Value == 0) return new SprintDto();

            var sprint = await db.Sprint.Include(i => i.Issues).SingleAsync(x => x.Id == id);
            var sprintdto = new SprintDto
            {
                Id = sprint.Id,
                StartDate = sprint.StartDate,
                FinishtDate = sprint.FinishtDate,
                IsEnded = sprint.IsEnded,
                Issues = sprint.Issues.Select(x => new IssueDto {
                    Id = x.Id,
                    Assignee = x.Assignee,
                    Reporter = x.Reporter,
                    Summary = x.Summary,
                    Description = x.Description,
                    Type = x.Type,
                    Status = x.Status,
                    Priority = x.Priority,
                    EstimatedTime = x.EstimatedTime,
                    Size = x.Size,
                    DueDate = x.DueDate,
                    EpicLink = x.EpicLink,
                }).ToList()
            };

            return sprintdto;
        }

        public async Task Update(SprintDto sprintDto)
        {
            await checkSprintHasIssues(sprintDto.Id);
            checkDate(sprintDto);
            await checkSprintCrossAsync(sprintDto);

            var sprint = await db.Sprint.FindAsync(sprintDto.Id);

            sprint.StartDate = sprintDto.StartDate;
            sprint.FinishtDate = sprintDto.FinishtDate;
            sprint.IsEnded = sprintDto.IsEnded;

            await db.SaveChangesAsync();
        }

        public async Task AddIssue(long sprintId, long issueId)
        {
            await db.SprintIssues.AddAsync(new SprintIssues() { SprintId = sprintId, IssueId = issueId });

            await db.SaveChangesAsync();
        }

        public async Task DeleteIssue(long sprintId, long issueId)
        {
            var sprintIssue = await db.SprintIssues.SingleAsync(x => x.IssueId == issueId && x.SprintId == sprintId);
            db.SprintIssues.Remove(sprintIssue);

            await db.SaveChangesAsync();
        }

        public Task MoveIssueToNextSprint(long issueId)
        {
            throw new NotImplementedException();
        }

        #region Validation
        private void checkDate(SprintDto model)
        {
            if (model.StartDate >= model.FinishtDate)
                throw new ArgumentException("Дата начала позже даты окончания :)");
        }

        private async Task checkSprintCrossAsync(SprintDto dto)
        {
            bool isSprintCross = await db.Sprint.AnyAsync(x => (dto.StartDate >= x.StartDate && dto.StartDate <= x.FinishtDate) || (dto.FinishtDate >= x.StartDate && dto.FinishtDate <= x.FinishtDate));
            if (isSprintCross)
                throw new ArgumentException("Переоды пересекаются");
        }

        private async Task checkSprintHasIssues(long sprintId)
        {
            bool hasIssues = await db.SprintIssues.AnyAsync(si => si.SprintId == sprintId);
            if (hasIssues)
                throw new ArgumentException("Спринт содержит задачи, сперва удалите задачи");
        }
        #endregion
    }
}
