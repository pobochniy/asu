using Atheneum.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Atheneum.Entity.Identity
{
    public class Epic
    {
        /// <summary>
        /// ID Эпика
        /// </summary>
        [Key]
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
        public IssuePriorityEnum Priority { get; set; }
        
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Время
        /// </summary>
        public DateTime? DueDate { get; set; }

        public virtual ICollection<TimeTracking> TimeTrackings { get; set; }

        public Epic()
        {
            TimeTrackings = new List<TimeTracking>();
        }
    }
}


