using System.ComponentModel.DataAnnotations;
using System;
using Atheneum.Enums;
using Atheneum.Dto.Sprint;
using System.Collections.Generic;

namespace Atheneum.Dto.Issue
{
    public class IssueDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Исполнитель
        /// </summary>
        public Guid? Assignee { get; set; }

        /// <summary>
        /// Инициатор
        /// </summary>
        [Required]
        public Guid Reporter { get; set; }

        /// <summary>
        /// Сводка
        /// </summary>
        [Required]
        public string Summary { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        [Required]
        public IssueTypeEnum Type { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        [Required]
        public IssueStatusEnum Status { get; set; }

        /// <summary>
        /// Приоритет
        /// </summary>
        [Required]
        public IssuePriorityEnum Priority { get; set; }

        /// <summary>
        /// Условный размер задачи
        /// </summary>
        public SizeEnum Size { get; set; }

        /// <summary>
        /// Предполагаемое время на задачу (вычисляется от размера задачи и исполнителя)
        /// </summary>
        public decimal? EstimatedTime { get; set; }

        /// <summary>
        /// Дата крайнего срока завершения события
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Ссылка на эпик
        /// </summary>
        public int? EpicLink { get; set; }

        /// <summary>
        /// Ссылка на sprints
        /// </summary>
        public List<SprintDto> Sprints { get; set; }
    }
}
