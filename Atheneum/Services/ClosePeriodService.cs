using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atheneum.Dto.ClosePeriod;
using Atheneum.Entity;
using Atheneum.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Atheneum.Services;

public class ClosePeriodService
{
    private readonly ApplicationContext _db;

    public ClosePeriodService(ApplicationContext context)
    {
        _db = context;
    }

    public async Task Calculate(DatePeriodDto dto, Guid currentUserId)
    {
        var hourlyPays = (await _db.HourlyPay
                .ToArrayAsync())
            .GroupBy(k => k.UserId)
            .ToDictionary(k => k.Key,
                v => v.OrderBy(o => o.StartedDate).ToArray());

        var timeTracking = (await _db.TimeTracking
                .ToArrayAsync())
            .Where(x => x.Date >= dto.From && x.Date <= dto.To)
            .GroupBy(k => k.UserId)
            .ToDictionary(k => k.Key,
                v => v.ToArray());

        var period = new CrystalProfitPeriod
        {
            Created = DateTime.Now,
            UserCreated = currentUserId,
            From = dto.From,
            To = dto.To,
            Payments = new List<CrystalPayment>()
        };
        foreach (var userId in hourlyPays.Keys)
        {
            var cashPayment = CalculateUserCash(dto, userId, hourlyPays, timeTracking);
            if (cashPayment.Cash > 0) period.Payments.Add(cashPayment);
        }

        await using var dbContextTransaction = await _db.Database.BeginTransactionAsync();
        await _db.CrystalProfitPeriods.AddAsync(period);
        var users = period.Payments.Select(x => x.UserId).ToArray();
        var dbUsers = await _db.Profiles.Where(x => users.Contains(x.Id)).ToArrayAsync();
        foreach (var dbUser in dbUsers)
        {
            dbUser.Cash += period.Payments.Single(x => x.UserId == dbUser.Id).Cash;
        }

        await _db.SaveChangesAsync();
        await dbContextTransaction.CommitAsync();
    }


    public async Task<IEnumerable<CrystalProfitPeriodDto>> GetList()
    {
        var res = await _db.CrystalProfitPeriods
            .ToDto()
            .OrderByDescending(x => x.From)
            .Take(10)
            .ToArrayAsync();
        
        return res;
    }

    private static CrystalPayment CalculateUserCash(DatePeriodDto dto, Guid userId,
        Dictionary<Guid, HourlyPay[]> hourlyPays,
        Dictionary<Guid, TimeTracking[]> timeTracking)
    {
        var daysCount = dto.To.DayNumber - dto.From.DayNumber;

        var userCash = new CrystalPayment
        {
            UserId = userId,
            Cash = 0
        };
        for (var day = 0; day <= daysCount; day++)
        {
            var stavka = hourlyPays[userId]
                .OrderByDescending(x => x.StartedDate)
                .FirstOrDefault(x => x.StartedDate <= dto.From.AddDays(day));
            if (stavka == null || !timeTracking.ContainsKey(userId)) continue;

            var workedHours = timeTracking[userId]
                .Where(x => x.Date == dto.From.AddDays(day))
                .ToArray();
            if (!workedHours.Any()) continue;

            userCash.Cash += stavka.Cash * (decimal) workedHours.Sum(x => (x.To - x.From).TotalMinutes) / 60;
        }

        return userCash;
    }
}