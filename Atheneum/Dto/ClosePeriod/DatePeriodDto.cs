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
    public DateOnly To { get; set; }
}

/// <summary>
/// Интервалы не могут пересекаться
/// </summary>
internal class NonOverlappingIntervals : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DatePeriodDto model = (DatePeriodDto) validationContext.ObjectInstance;

        var db = (ApplicationContext) validationContext.GetRequiredService(typeof(ApplicationContext));

        if (db.CrystalProfitPeriods.Any(x => x.From >= model.From) ||
            db.CrystalProfitPeriods.Any(x => x.To >= model.To))
        {
            return new ValidationResult(ErrorMessage = "Интервалы не могут пересекаться");
        }

        return ValidationResult.Success;
    }
}