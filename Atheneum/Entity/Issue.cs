using System;
using Atheneum.Enums;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atheneum.Entity.Identity
{
    /// <summary>
    /// Модель страницы создания события (story, task, bug, knowledge, meeting)
    /// </summary>
    
    public class Issue
    {
        
        /// Уникальный номер события
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; } 

        /// Исполнитель
        public Guid? Assignee { get; set; }      
        
        /// Инициатор
        public Guid Reporter { get; set; }  

        /// Сводка
        public string Summary { get; set; }
        
        /// Описание
        public string Description { get; set; }     

        /// Тип события
        public IssueTypeEnum Type { get; set; }
        
        /// Статус 
        public IssueStatusEnum Status { get; set; } 

        /// Приоритет события
        public IssuePriorityEnum Priority { get; set; } 

        /// Предполагаемое время исполнтеля
        public decimal? AssigneeEstimatedTime { get; set; }

        /// Предполагаемое время инициатора
        public decimal? ReporterEstimatedTime { get; set; }

        /// Дата создания события
        public DateTime CreateDate { get; set; }

        /// Дата крайнего срока завершения события
        public DateTime? DueDate { get; set; }

        /// Ссылки на эпики
        public int? EpicLink { get; set; }

    }

    public class IssueConfiguration : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder
               .HasIndex(u => u.Id)
               .IsUnique();     
        }   
    }
}
/*public virtual ICollection<Issue> Issues { get; set; }

public Issue()
{
    Issues = new List<Issue>();
}*/