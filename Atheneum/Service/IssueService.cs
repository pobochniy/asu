using Atheneum.Dto.Auth;
using Atheneum.Entity.Identity;
using Atheneum.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atheneum.Services
{
    class IssueService : IIssue
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

        public Task Delete(IssueDto model)
        {
            throw new NotImplementedException();
        }

        public async Task Details(IssueDto dto)
        {
            Issue issue = null;

            issue = await db.Issue.Include(x => x.Id).SingleAsync(x => x.Id == dto.Id);


        }

        public Task<IEnumerable<IssueDto>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task Update(IssueDto model)
        {
            throw new NotImplementedException();
        }

        Task<IssueDto> IIssue.Details(IssueDto model)
        {
            throw new NotImplementedException();
        }
    }
}
