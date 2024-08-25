using Atheneum.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Atheneum.Dto.ClosePeriod;

namespace Atheneum.Mapping
{
    public static partial class DbMapping
    {
        public static IQueryable<CrystalProfitPeriodDto> ToDto(this DbSet<CrystalProfitPeriod> entity)
        {
            return entity.Select(x => new CrystalProfitPeriodDto
            {
                Id = x.Id,
                From = x.From,
                To = x.To,
                Created = x.Created,
                UserCreated = x.UserCreated,
                Payments = x.Payments.Select(p=> new CrystalPaymentDto
                {
                    Id = p.Id,
                    Cash = p.Cash,
                    UserId = p.UserId
                })
            });
        }
    }
}
