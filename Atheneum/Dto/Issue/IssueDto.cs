using System.ComponentModel.DataAnnotations;
using System;
using Atheneum.Enums;

namespace Atheneum.Dto.Issue
{
    public class IssueDto
    {
        /// Идентификатор
        public long? Id { get; set; }

        /// Исполнитель
        public Guid? Assignee { get; set; }

        /// Инициатор
        [Required]
        public Guid Reporter { get; set; }

        /// Сводка
        [Required]
        public string Summary { get; set; }

        /// Описание
        [Required]
        public string Description { get; set; }

        /// Тип события
        [Required]
        public IssueTypeEnum Type { get; set; }

        /// Статус 
        [Required]
        public IssueStatusEnum Status { get; set; }

        /// Приоритет события
        [Required]
        public IssuePriorityEnum Priority { get; set; }

        /// Предполагаемое время исполнтеля
        public decimal? AssigneeEstimatedTime { get; set; }

        /// Предполагаемое время инициатора
        public decimal? ReporterEstimatedTime { get; set; }

        /// Дата крайнего срока завершения события
        public DateTime? DueDate { get; set; }

        /// Ссылки на эпики
        public int? EpicLink { get; set; }
    }
}
