﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Atheneum.Dto.HourlyPay
{
    public class HourlyPayDto
    {
        /// <summary>
        /// Id Ставки
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID работника
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// Дата начала действия ставки
        /// </summary>
        [Required]
        public DateOnly StartedDate { get; set; }

        /// <summary>
        /// Стоимость часа сотрудника
        /// </summary>
        [Required]
        public decimal Cash { get; set; }

        /// <summary>
        /// Id пользователя создавшего запись 
        /// </summary>
        public Guid UserIdCreated { get; set; }

        /// <summary>
        /// Дата создания записи
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}
