using Atheneum.Dto.CashFlow;
using Atheneum.Entity;
using Atheneum.Entity.Identity;
using Atheneum.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atheneum.Service
{
    public class CashFlowService // : ICashFlow
    {
        private ApplicationContext db;

        public CashFlowService(ApplicationContext context)
        {
            db = context;
        }

        public async Task Create(CashFlowDto dto)
        {
            var cashflow = new CashFlow
            {
                UserIdPassed = dto.UserIdPassed,
                UserIdReceived = dto.UserIdReceived,
                Cash = dto.Cash,
                Created = dto.Created,
                Comment = dto.Comment
            };
            await db.CashFlow.AddAsync(cashflow);
            await db.SaveChangesAsync();
            
        }

        public async Task Delete(long id)
        {
            var i = await db.CashFlow.FindAsync(id);
            db.CashFlow.Remove(i);

            await db.SaveChangesAsync();
        }

        public Task Read(long? id)
        {
            
            var cashflow = new CashFlow
            {
                UserIdPassed = 
            }
        }

        public Task Update(ICashFlow model)
        {
            throw new NotImplementedException();
        }
    }
}
