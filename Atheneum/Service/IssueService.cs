using Atheneum.Dto.Issue;
using Atheneum.Entity.Identity;
using Atheneum.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atheneum.Services
{
    public class IssueService : IIssue
    {
        private ApplicationContext db;

        public IssueService(ApplicationContext context)
        {
            db = context;
        }

        public async Task<long> Create(IssueDto dto)
        {

            var issue = new Issue
            {
                Assignee = dto.Assignee,
                Reporter = dto.Reporter,
                Summary = dto.Summary,
                Description = dto.Description,
                Type = dto.Type,
                Status = dto.Status,
                Priority = dto.Priority,
                AssigneeEstimatedTime = dto.AssigneeEstimatedTime,
                ReporterEstimatedTime = dto.ReporterEstimatedTime,
                CreateDate = DateTime.UtcNow,
                DueDate = dto.DueDate,
                EpicLink = dto.EpicLink
            };

            await db.Issue.AddAsync(issue);
            await db.SaveChangesAsync();

            return issue.Id;
        }

        public async Task<IssueDto> Details(long id)
        {
            var issue = await db.Issue.FindAsync(id);
            var issuedto = new IssueDto
            {
                Id = issue.Id,
                Assignee = issue.Assignee,
                AssigneeEstimatedTime = issue.AssigneeEstimatedTime,
                Description = issue.Description,
                DueDate = issue.DueDate,
                EpicLink = issue.EpicLink,
                Priority = issue.Priority,
                Reporter = issue.Reporter,
                ReporterEstimatedTime = issue.ReporterEstimatedTime,
                Status = issue.Status,
                Summary = issue.Summary,
                Type = issue.Type
            };

            return issuedto;

        }

        public async Task Delete(long id)
        {
            var i = await db.Issue.FindAsync(id);
            db.Issue.Remove(i);

            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<IssueDto>> GetList()
        {
            var issues = await db.Issue
            .Select(x => new IssueDto
            {
                Assignee = x.Assignee,
                AssigneeEstimatedTime = x.AssigneeEstimatedTime,
                Description = x.Description,
                DueDate = x.DueDate,
                EpicLink = x.EpicLink,
                Priority = x.Priority,
                Reporter = x.Reporter,
                ReporterEstimatedTime = x.ReporterEstimatedTime,
                Status = x.Status,
                Summary = x.Summary,
                Type = x.Type
            })
            .ToArrayAsync();

            return issues;
        }

        public async Task Update(IssueDto issuedto)
        {
            var issue = await db.Issue.FindAsync(issuedto.Id);


            issue.Assignee = issuedto.Assignee;
            issue.Reporter = issuedto.Reporter;
            issue.Summary = issuedto.Summary;
            issue.Description = issuedto.Description;
            issue.Type = issuedto.Type;
            issue.Status = issuedto.Status;
            issue.Priority = issuedto.Priority;
            issue.AssigneeEstimatedTime = issuedto.AssigneeEstimatedTime;
            issue.ReporterEstimatedTime = issuedto.ReporterEstimatedTime;
            issue.DueDate = issuedto.DueDate;
            issue.EpicLink = issuedto.EpicLink;
            issue.RefreshDate = DateTime.UtcNow;

            await db.SaveChangesAsync();
        }
    }
}
