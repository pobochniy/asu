using Atheneum.Entity.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

/*  Интервалы не могут пересекаться

    Интервал не более 4 часов

    Не более 10 часов в сутки

    Дата сегодняшняя или вчерашняя

    Редактировать можно сегодняшние и вчерашние записи

    Должно быть заполнено что-то одно, таскИд или эпикИд

    Пользователь должен проставляться текущий, за других нельзя править и создавать*/

namespace Atheneum.Validations.TimeTrackingValidation
{
    internal class TimeTrackingValidationAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var db = (ApplicationContext)validationContext.GetService(typeof(ApplicationContext));

            TimeTracking timeTracking = value as TimeTracking;

            // Дата сегодняшняя или вчерашняя
            if (timeTracking.Date.Date != DateTime.Now.Date ||
                timeTracking.Date.Date != DateTime.Today.AddDays(-1).Date)
            {
                return new ValidationResult(ErrorMessage = "Дата должна быть сегодняшняя или вчерашняя");
            }

            // Интервал не более 4 часов (будет очень смешно, если заработает)
            else if (timeTracking.To > timeTracking.From.AddHours(+4)) 
            {
                return new ValidationResult(ErrorMessage = "Интервал не должен превышать 4 часа");
            }
                return ValidationResult.Success;
        }
    }

    // Интервалы не могут пересекаться
    internal class IntervalsCannotIntersect : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var db = (ApplicationContext)validationContext.GetService(typeof(ApplicationContext));

            TimeTracking timeTracking = (TimeTracking)validationContext.ObjectInstance;

            db.TimeTracking.
            if (
            {
               
            };

            return ValidationResult.Success;
        }
    }













    ////Интервал не более указанных часов
    internal class IntervalNotMoreThanHoursAttribute : ValidationAttribute
    {
        private int interval;

        public IntervalNotMoreThanHoursAttribute(int interval)
        {
            this.interval = interval;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            TimeTracking timeTracking = (TimeTracking)validationContext.ObjectInstance;

            if (timeTracking.To > timeTracking.From.AddHours(+interval))
            {
                // Надо как-то просклонять
                return new ValidationResult(ErrorMessage = $"Интервал не может превышать {interval} часа");
            };

            return ValidationResult.Success;
        }
    }
}
