using Atheneum.Dto.Auth;
using Atheneum.Entity.Identity;
using Atheneum.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Atheneum.Services
{
    class IssueService
    {
        private ApplicationContext db;

        public IssueService(ApplicationContext context)
        {
            db = context;
        }

        public async Task Create(IssueDto dto)
        {
            var issue = new Issue
            {
                Id = dto.Id,
                Assignee = dto.Assignee, 
                Reporter = dto.Reporter,
                Summary = dto.Summary,
                Description = dto.Description,
                Type = dto.Type,
                Status = dto.Status,
                Priority = dto.Priority,
                AssigneeEstimatedTime = dto.AssigneeEstimatedTime,
                ReporterEstimatedTime = dto.ReporterEstimatedTime,
                CreateDate = dto.CreateDate, 
                DueDate = dto.DueDate,
                EpicLink = dto.EpicLink

            };

            await db.Issue.AddAsync(issue);
            await db.SaveChangesAsync();
        }

        public async Task Details(IssueDto dto)
        {
            Issue issue = null;
            
            issue = await db.Issue.Include(x => x.Id).SingleAsync(x => x.Id == dto.Id);
            

        }


    }
}
