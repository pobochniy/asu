using Atheneum.Dto.CashFlow;
using Atheneum.Entity;
using Atheneum.Entity.Identity;
using Atheneum.Interface;
using Atheneum.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atheneum.Service
{
    public class CashFlowService : ICashFlow
    {
        private ApplicationContext db;

        public CashFlowService(ApplicationContext context)
        {
            db = context;
        }

        public async Task<Guid> Create(CashFlowDto dto)
        {
            var sender = await db.Profiles.SingleAsync(x => x.Id == dto.UserIdPassed);
            var recipient = await db.Profiles.SingleAsync(x => x.Id == dto.UserIdReceived);

            if (sender.Cash < dto.Cash) throw new Exception("Недостаточно средств");

            sender.Cash -= dto.Cash;
            recipient.Cash += dto.Cash;

            var cashflow = new CashFlow
            {
                UserIdPassed = dto.UserIdPassed,
                UserIdReceived = dto.UserIdReceived,
                Cash = dto.Cash,
                Created = DateTime.Now,
                Comment = dto.Comment
            };
            await db.CashFlow.AddAsync(cashflow);
            await db.SaveChangesAsync();

            return cashflow.Id;
        }

        //public async Task Delete(Guid id)
        //{
        //    var entity = await db.CashFlow.SingleAsync(x => x.Id == id);
        //    db.CashFlow.Remove(entity);

        //    await db.SaveChangesAsync();
        //}

        public async Task<CashFlowDto> Details(Guid id)
        {
            var res = await db.CashFlow.ToDto().SingleAsync(x => x.Id == id);

            return res;
        }

        public async Task<IEnumerable<CashFlowDto>> GetList(Guid? userId)
        {
            var query = db.CashFlow.ToDto();

            if (userId != null) query = query.Where(x => x.UserIdPassed == userId || x.UserIdReceived == userId);

            var res = await query.ToArrayAsync();

            return res;
        }

        //public Task Update(ICashFlow model)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
