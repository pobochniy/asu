using Atheneum.Dto.Issue;
using Atheneum.Enums;
using Atheneum.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Atheneum.Entity;

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
                Status = IssueStatusEnum.todo,
                Priority = dto.Priority,
                Size = dto.Size,
                CreateDate = DateTime.UtcNow,
                DueDate = dto.DueDate,
                EpicLink = dto.EpicLink
            };

            issue.EstimatedTime = await CalcEstimatedTime(dto.Assignee, dto.Size);

            await db.Issue.AddAsync(issue);
            await db.SaveChangesAsync();

            return issue.Id;
        }

        public async Task<IssueDto> Details(long? id)
        {
            if (!id.HasValue) throw new ArgumentException("Сломано");

            if (id.Value == 0) return new IssueDto();

            var issue = await db.Issue.FindAsync(id);
            var issuedto = new IssueDto
            {
                Id = issue.Id,
                Assignee = issue.Assignee,
                EstimatedTime = issue.EstimatedTime,
                Description = issue.Description,
                DueDate = issue.DueDate,
                EpicLink = issue.EpicLink,
                Priority = issue.Priority,
                Reporter = issue.Reporter,
                Size = issue.Size,
                Status = issue.Status,
                Summary = issue.Summary,
                Type = issue.Type
            };

            return issuedto;

        }

        public async Task<IEnumerable<IssueDto>> GetList(long? epicId)
        {
            var issues = await db.Issue
                .Select(x => new IssueDto
                {
                    Id = x.Id,
                    Assignee = x.Assignee,
                    EstimatedTime = x.EstimatedTime,
                    Description = x.Description,
                    DueDate = x.DueDate,
                    EpicLink = x.EpicLink,
                    Priority = x.Priority,
                    Reporter = x.Reporter,
                    Size = x.Size,
                    Status = x.Status,
                    Summary = x.Summary,
                    Type = x.Type
                })
                .Where(i => i.EpicLink == (epicId ?? i.EpicLink))
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
            issue.EstimatedTime = issuedto.EstimatedTime;
            issue.Size = issuedto.Size;
            issue.DueDate = issuedto.DueDate;
            issue.EpicLink = issuedto.EpicLink;

            await db.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var i = await db.Issue.FindAsync(id);
            db.Issue.Remove(i);

            await db.SaveChangesAsync();
        }

        private async Task<decimal?> CalcEstimatedTime(Guid? assignee, SizeEnum size)
        {
            decimal? res = 0;

            if (assignee.HasValue)
            {
                var countTasks = await db.Issue.Where(x => x.Assignee == assignee && x.Status == IssueStatusEnum.resolve && x.Size == size).CountAsync();
                res = countTasks > 10
                    ? await db.Issue.Where(x => x.Assignee == assignee && x.Status == IssueStatusEnum.resolve && x.Size == size).Select(x => x.EstimatedTime).AverageAsync()
                    : GetDefaultAverage(size);
            }
            else
            {
                res = GetDefaultAverage(size);
            }

            return res;
        }

        private decimal GetDefaultAverage(SizeEnum size)
        {
            switch (size)
            {
                case SizeEnum.XS: return (decimal)0.5;
                case SizeEnum.S: return 1;
                case SizeEnum.M: return 4;
                case SizeEnum.L: return 8;
                case SizeEnum.XL: return 16;
                default:
                    return 0;
            }
        }

    }
}
