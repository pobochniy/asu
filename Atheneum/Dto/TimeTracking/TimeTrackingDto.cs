using Atheneum.Validations.TimeTrackingValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Atheneum.Dto.TimeTracking
{
    [TimeTrackingValidation]
    public class TimeTrackingDto
    {
        /// <summary>
        /// Идентификатор TimeTracking
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// День на который списывать время
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Время "с"
        /// </summary>
        [Required]
        public DateTime? From { get; set; }

        /// <summary>
        /// Время "по"
        /// </summary>
        //[IntervalNotMoreThanHours(4)]
        public DateTime? To { get; set; }

        /// <summary>
        /// Описание работы
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Пользователь, потративший время
        /// </summary>
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
