using System;
using Atheneum.Enums;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Atheneum.Dto.Epic
{
    public class EpicDto
    {
        /// <summary>
        /// Идентификатор эпика
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Исполнитель
        /// </summary>
        public Guid? Assignee { get; set; }

        /// <summary>
        /// Инициатор
        /// </summary>
        public Guid? Reporter { get; set; }

        /// <summary>
        /// Приоритет
        /// </summary>
        [Required]
        public IssuePriorityEnum Priority { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата окончания эпика
        /// </summary>
        public DateTime? DueDate { get; set; }
    }
}
