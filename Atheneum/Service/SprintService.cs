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
            var sprints = await db.Sprints
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
            var sprint = new Sprint
            {
                StartDate = dto.StartDate,
                FinishtDate = dto.FinishtDate,
                IsEnded = 0
            };
            sprint.Issues.AddRange((IEnumerable<Issue>)dto.Issues);
            await db.Sprints.AddAsync(sprint);
            await db.SaveChangesAsync();

            return sprint.Id;
        }

        public async Task Delete(long Id)
        {
            var s = await db.Sprints.FindAsync(Id);
            db.Sprints.Remove(s);

            await db.SaveChangesAsync();
        }

        public async Task<SprintDto> Details(long? id)
        {
            if (!id.HasValue) throw new ArgumentException("Сломано");

            if (id.Value == 0) return new SprintDto();

            var sprint = await db.Sprints.FindAsync(id);
            var sprintdto = new SprintDto
            {
                Id = sprint.Id,
                StartDate = sprint.StartDate,
                FinishtDate = sprint.FinishtDate,
                IsEnded = sprint.IsEnded
            };
            sprintdto.Issues.AddRange((IEnumerable<Dto.Issue.IssueDto>)sprint.Issues);

            return sprintdto;
        }

        public async Task Update(SprintDto sprintdto)
        {
            var sprint = await db.Sprints.FindAsync(sprintdto.Id);

            sprint.StartDate = sprintdto.StartDate;
            sprint.FinishtDate = sprintdto.FinishtDate;
            sprint.IsEnded = sprintdto.IsEnded;

            await db.SaveChangesAsync();
        }

        public async Task AddIssues(long sprintId, List<long> issues)
        {
            if (!(issues.Count > 0)) throw new ArgumentException("Сломано");

            await db.SprintIssues.AddRangeAsync(issues.Select(c => new Sprint.SprintIssues() { SprintId = sprintId, IssueId = c }));
        }

        public async Task DeleteIssue(long sprintId, long issueId)
        {
            var model = new SprintIssues() { SprintId = sprintId, IssueId = issueId };
            var sprintIssue = await db.SprintIssues.FindAsync(model);
            db.SprintIssues.Remove(sprintIssue);
            await db.SaveChangesAsync();
        }
    }
}
