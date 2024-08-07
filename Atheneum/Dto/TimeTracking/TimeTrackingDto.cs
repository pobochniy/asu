﻿using Atheneum.Validations.TimeTrackingValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Atheneum.Dto.TimeTracking
{
    [TaskOrEpic]
    [NoMoreThanTenHoursADay]
    [IntervalNoMoreThanFourHours]
    public class TimeTrackingDto
    {
        /// <summary>
        /// Идентификатор TimeTracking
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// День на который списывать время
        /// </summary>
        [DateTodayOrYesterday]
        public DateOnly? Date { get; set; }

        /// <summary>
        /// Время "с"
        /// </summary>
        [Required]
        public TimeOnly? From { get; set; }

        /// <summary>
        /// Время "по"
        /// </summary>
        [Required]
        public TimeOnly? To { get; set; }

        /// <summary>
        /// Описание работы
        /// </summary>
        [Required]
        public string Comment { get; set; }

        /// <summary>
        /// Пользователь, потративший время
        /// </summary>
        // [CurrentUser]
        public Guid? UserId { get; set; }

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
