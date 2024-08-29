using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Atheneum.Extentions.Auth;
using Atheneum.Dto.TimeTracking;
using Atheneum.Entity;

namespace Atheneum.Validations.TimeTrackingValidation;

/// <summary>
/// Интервал списания не должен превышать 4 часа
/// </summary>
internal class IntervalNoMoreThanFourHours : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        // var db = (ApplicationContext) validationContext.GetService(typeof(ApplicationContext));

        TimeTrackingDto model = (TimeTrackingDto) validationContext.ObjectInstance;

        if ((model.To.Value - model.From.Value).TotalMinutes > 4 * 60)
        {
            return new ValidationResult(ErrorMessage = "Интервал не должен превышать 4 часа");
        }

        return ValidationResult.Success;
    }
}

/// <summary>
/// Должно быть заполнено что-то одно, IssueId или EpicId
/// </summary>
internal class TaskOrEpic : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        TimeTrackingDto model = (TimeTrackingDto) validationContext.ObjectInstance;

        if (model.IssueId.HasValue || model.EpicId.HasValue)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage = "Должно быть заполненно IssueId или EpicId");
    }
}

/// <summary>
/// Создание и редактирование возможно только за текущего пользователя
/// </summary>
internal class CurrentUser : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            Guid currentUser = (Guid) value;

            var httpContextAccessor =
                (IHttpContextAccessor) validationContext.GetService(typeof(IHttpContextAccessor));

            var userId = httpContextAccessor.HttpContext.User.GetUserId();

            if (currentUser != userId)
            {
                return new ValidationResult(ErrorMessage =
                    "Создание и редактирование возможно только за текущего пользователя");
            }

            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage = "UserId не заполнено");
    }
}

/// <summary>
/// Не более 10 часов в сутки
/// Интервалы не могут пересекаться
/// </summary>
internal class NoMoreThanTenHoursADay : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        TimeTrackingDto model = (TimeTrackingDto) validationContext.ObjectInstance;

        if (model.Date == null)
        {
            return new ValidationResult(ErrorMessage = "Заполните поле 'Date'");
        }

        var db = (ApplicationContext) validationContext.GetService(typeof(ApplicationContext));

        var httpContextAccessor = (IHttpContextAccessor) validationContext.GetService(typeof(IHttpContextAccessor));

        var userId = httpContextAccessor.HttpContext.User.GetUserId();

        var intervals = db.TimeTracking
            .Where(x => x.Date == model.Date.Value && x.UserId == userId)
            .Select(res => new
            {
                from = res.From,
                to = res.To
            }).ToList();

        var totalAmountOfTimeSpent = intervals.Select(x => (x.to - x.from).TotalMinutes).Sum();

        if (totalAmountOfTimeSpent + (model.To - model.From).Value.TotalMinutes > 10 * 60)
        {
            return new ValidationResult(ErrorMessage = $"Списанные интервалы за сутки не должны превышать 10 часов (уже {totalAmountOfTimeSpent/60})");
        }

        foreach (var interval in intervals)
        {
            if (model.From > interval.from && model.From < interval.to)
            {
                return new ValidationResult(ErrorMessage = $"Интервалы не могут пересекаться ({interval.from}-{interval.to})");
            }
            if (model.To > interval.from && model.To < interval.to)
            {
                return new ValidationResult(ErrorMessage = $"Интервалы не могут пересекаться ({interval.from}-{interval.to})");
            }
        }

        return ValidationResult.Success;
    }
}

/// <summary>
/// Дата сегодняшняя или вчерашняя
/// </summary>
internal class DateTodayOrYesterday : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateOnly modelDate = (DateOnly) value;
        var today = DateOnly.FromDateTime(DateTime.Now);

        if (modelDate == today ||
            modelDate == today.AddDays(-1))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage = "Списать время возможно только за сегодня и вчера");
    }
}