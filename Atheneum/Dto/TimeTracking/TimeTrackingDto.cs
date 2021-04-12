using Atheneum.Validations.TimeTrackingValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Atheneum.Dto.TimeTracking
{
    [NoMoreThanTenHoursADay]
    [TaskOrEpic]
    [IntervalNoMoreThanFourHours]
    public class TimeTrackingDto
    {
        /// <summary>
        /// Идентификатор TimeTracking
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// День на который списывать время
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Время "с"
        /// </summary>
        [Required]
        public DateTime From { get; set; }

        /// <summary>
        /// Время "по"
        /// </summary>
        [Required]
        public DateTime To { get; set; }

        /// <summary>
        /// Описание работы
        /// </summary>
        [Required]
        public string Comment { get; set; }

        /// <summary>
        /// Пользователь, потративший время
        /// </summary>
        [Required]
        [CurrentUser]
        public Guid UserId { get; set; }

        /// <summary>
        /// Задача, на которую потрачено время
        /// </summary>
        public long? IssueId { get; set; }

        /// <summary>
        /// Эпик, на который потрачено время
        /// </summary>
        public int? EpicId { get; set; }
    }
}
