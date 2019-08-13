using System;
using Atheneum.Enums;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atheneum.Entity.Identity
{
    /// <summary>
    /// Модель страницы создания инцидента (story, task, bug, knowledge, meeting)
    /// </summary>
    
    public class Issue
    {
        [Key]

        /// Уникальный номер события
        public long Id { get; set; } 

        /// Ответственный
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

        /// Затраченное время (фактическое)
        public decimal? AssigneeEstimatedTime { get; set; }

        /// Предполагаемое время выполнения
        public decimal? ReporterEstimatedTime { get; set; }

        /// Дата создания события
        public DateTime CreateDate { get; set; }

        /// Дата крайнего скрока завершения события
        public DateTime? DueDate { get; set; }

        /// Ссылуи на эпики
        public int EpicLink { get; set; }

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
