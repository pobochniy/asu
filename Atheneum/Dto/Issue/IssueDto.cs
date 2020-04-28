using System.ComponentModel.DataAnnotations;
using System;
using Atheneum.Enums;

namespace Atheneum.Dto.Issue
{
    public class IssueDto
    {
        public long? Id { get; set; }

        public Guid? Assignee { get; set; }

        [Required]
        public Guid Reporter { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public IssueTypeEnum Type { get; set; }

        [Required]
        public IssueStatusEnum Status { get; set; }

        [Required]
        public IssuePriorityEnum Priority { get; set; }

        /// <summary>
        /// Предполагаемое время исполнителя
        /// </summary>
        public decimal? AssigneeEstimatedTime { get; set; }

        /// <summary>
        /// Предполагаемое время инициатора
        /// </summary>
        public decimal? ReporterEstimatedTime { get; set; }

        /// <summary>
        /// Дата крайнего срока завершения события
        /// </summary>
        public DateTime? DueDate { get; set; }

        public int? EpicLink { get; set; }
    }
}
