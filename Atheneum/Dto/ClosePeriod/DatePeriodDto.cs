using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Atheneum.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace Atheneum.Dto.ClosePeriod;

[NonOverlappingIntervals]
public class DatePeriodDto
{
    [Required]
    public DateOnly From { get; set; }
    
    [Required]
    [CloseAfterTwoDays]
    public DateOnly To { get; set; }
}

/// <summary>
/// Периоды закрываются последовательно. Интервалы не могут пересекаться
/// </summary>
internal class NonOverlappingIntervals : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DatePeriodDto model = (DatePeriodDto) validationContext.ObjectInstance;

        var db = (ApplicationContext) validationContext.GetRequiredService(typeof(ApplicationContext));
        var lastInterval = db.CrystalProfitPeriods
            .OrderByDescending(x => x.Id)
            .FirstOrDefault();
        
        if (lastInterval != null && lastInterval.To > model.From)
        {
            return new ValidationResult(ErrorMessage = "Периоды закрываются последовательно. Интервалы не могут пересекаться");
        }

        return ValidationResult.Success;
    }
}

/// <summary>
/// Период закрывается не раньше, чем через два дня
/// </summary>
internal class CloseAfterTwoDays : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateOnly modelDate = (DateOnly) value;
        var today = DateOnly.FromDateTime(DateTime.Now);

        if (modelDate < today.AddDays(-2))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage = "Закрыть период можно только через 2 дня");
    }
}