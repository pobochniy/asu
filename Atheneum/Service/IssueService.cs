using Atheneum.Dto.Auth;
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

        public async Task Delete(long id)
        {
            db.Issue.Remove(db.Issue.Find(id));
            await db.SaveChangesAsync();    
        }

        public Task<IssueDto> Details(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IssueDto>> GetList()
        {
            //db.Issue.FromSql("SELECT * FROM Issue").ToList();
                
                var issues = await db.Issue
                .Select(x => new IssueDto{ })
                .ToArrayAsync();

                return issues;
        }

        public Task Update(IssueDto model)
        {
            throw new NotImplementedException();
        }
    }
}
