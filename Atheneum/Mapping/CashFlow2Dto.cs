using Atheneum.Dto.CashFlow;
using Atheneum.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Atheneum.Mapping
{
    public static partial class DbMapping
    {
        public static IQueryable<CashFlowDto> ToDto(this DbSet<CashFlow> entity)
        {
            return entity.Select(x => new CashFlowDto
            {
                Id = x.Id,
                UserIdPassed = x.UserIdPassed,
                UserIdReceived = x.UserIdReceived,
                Created = x.Created,
                Cash = x.Cash,
                Comment = x.Comment
            });
        }
    }
}
