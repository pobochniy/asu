using Atheneum.Dto.HourlyPay;
using Atheneum.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atheneum.Services
{
    public class HourlyPayService
    {
        readonly ApplicationContext _db;

        public HourlyPayService(ApplicationContext context)
        {
            _db = context;
        }

        public async Task<int> Create(HourlyPayDto dto)
        {
            //проверяем существование юзеров
            var currentUser = await _db.Profiles.SingleAsync(x => x.Id == dto.UserIdCreated);
            var createdUser = await _db.Profiles.SingleAsync(x => x.Id == dto.UserId);

            var lastData = await _db.HourlyPay.OrderByDescending(x => x.StartedDate).FirstOrDefaultAsync(x => x.UserId == dto.UserId);

            if (lastData != null && lastData.StartedDate > dto.StartedDate)
            {
                throw new Exception("Дата назначения часовой ставки должна быть не раньше уже имеющейся");
            }

            var hourlyPay = new HourlyPay
            {
                CreatedDate = DateTime.Now,
                Cash = dto.Cash,
                StartedDate = dto.StartedDate,
                UserId = dto.UserId,
                UserIdCreated = dto.UserIdCreated
            };

            await _db.HourlyPay.AddAsync(hourlyPay);
            await _db.SaveChangesAsync();

            return hourlyPay.Id;
        }

        public async Task<HourlyPayDto> Details(int Id)
        {
            if (Id == 0) return new HourlyPayDto();

            var hourlyPay = await _db.HourlyPay.FindAsync(Id);
            var hourlyPayDto = new HourlyPayDto
            {
                Id = hourlyPay.Id,
                CreatedDate = hourlyPay.CreatedDate,
                Cash = hourlyPay.Cash,
                StartedDate = hourlyPay.StartedDate,
                UserId = hourlyPay.UserId,
                UserIdCreated = hourlyPay.UserIdCreated
            };

            return hourlyPayDto;
        }

        public async Task Update(HourlyPayDto dto)
        {
            var hourlyPay = await _db.HourlyPay.FindAsync(dto.Id);

            hourlyPay.Id = dto.Id;
            hourlyPay.CreatedDate = dto.CreatedDate;
            hourlyPay.Cash = dto.Cash;
            hourlyPay.StartedDate = dto.StartedDate;
            hourlyPay.UserId = dto.UserId;
            hourlyPay.UserIdCreated = dto.UserIdCreated;

            await _db.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var o = await _db.HourlyPay.FindAsync(Id);
            _db.HourlyPay.Remove(o);

            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<HourlyPayDto>> GetList(Guid? userId)
        {
            var query = _db.HourlyPay
                .Select(x => new HourlyPayDto
                {
                    Id = x.Id,
                    CreatedDate = x.CreatedDate,
                    Cash = x.Cash,
                    StartedDate = x.StartedDate,
                    UserId = x.UserId,
                    UserIdCreated = x.UserIdCreated
                });

            if (userId != null)
            {
                query = query.Where(x => x.UserId == userId);
            }

            var hourlyPay = await query.ToArrayAsync();

            return hourlyPay;
        }
    }
}
