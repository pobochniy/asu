using Atheneum.Dto.HourlyPay;
using Atheneum.Entity.Identity;
using Atheneum.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atheneum.Service
{
    public class HourlyPayService : IHourlyPay
    {
        ApplicationContext db;

        public HourlyPayService(ApplicationContext context)
        {
            db = context;
        }

        public async Task<int> Create(HourlyPayDto dto)
        {
            var hourlyPay = new HourlyPay
            {
                Created = dto.Created,
                Cash = dto.Cash,
                Started = dto.Started,
                UserId = dto.UserId,
                UserIdCreated = dto.UserIdCreated
            };

            await db.HourlyPay.AddAsync(hourlyPay);
            await db.SaveChangesAsync();

            return hourlyPay.Id;
        }

        public async Task<HourlyPayDto> Details(int Id)
        {
            if (Id == 0) return new HourlyPayDto();

            var hourlyPay = await db.HourlyPay.FindAsync(Id);
            var hourlyPayDto = new HourlyPayDto
            {
                Id = hourlyPay.Id,
                Created = hourlyPay.Created,
                Cash = hourlyPay.Cash,
                Started = hourlyPay.Started,
                UserId = hourlyPay.UserId,
                UserIdCreated = hourlyPay.UserIdCreated
            };

            return hourlyPayDto;
        }

        public async Task Update(HourlyPayDto dto)
        {
            var hourlyPay = await db.HourlyPay.FindAsync(dto.Id);

            hourlyPay.Id = dto.Id;
            hourlyPay.Created = dto.Created;
            hourlyPay.Cash = dto.Cash;
            hourlyPay.Started = dto.Started;
            hourlyPay.UserId = dto.UserId;
            hourlyPay.UserIdCreated = dto.UserIdCreated;

            await db.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var o = await db.HourlyPay.FindAsync(Id);
            db.HourlyPay.Remove(o);

            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<HourlyPayDto>> GetList(int Id)
        {
            var hourlyPay = await db.HourlyPay
                .Select(x => new HourlyPayDto
                {
                    Id = x.Id,
                    Created = x.Created,
                    Cash = x.Cash,
                    Started = x.Started,
                    UserId = x.UserId,
                    UserIdCreated = x.UserIdCreated
                }).ToArrayAsync();

            return hourlyPay;
        }
    }
}
