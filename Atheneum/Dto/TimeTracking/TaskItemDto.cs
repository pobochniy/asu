using Atheneum.Validations.TimeTrackingValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Atheneum.Dto.TimeTracking
{
    /// <summary>
    /// Список задач
    /// </summary>
    public class TaskItemDto
    {
        /// <summary>
        /// IssueId или EpicId
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Тип Issue или Epic
        /// </summary>
        public string Type { get; set; }
    }
}
