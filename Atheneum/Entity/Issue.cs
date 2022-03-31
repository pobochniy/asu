using Atheneum.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Atheneum.Entity;

/// <summary>
/// Модель страницы создания события (story, task, bug, knowledge, meeting)
/// </summary>
public class Issue
{
    /// <summary>
    /// Уникальный номер события
    /// </summary>
    [Key]
    public long Id { get; set; }

    /// <summary>
    /// Исполнитель
    /// </summary>
    public Guid? Assignee { get; set; }

    /// <summary>
    /// Инициатор
    /// </summary>
    public Guid Reporter { get; set; }

    /// <summary>
    /// Сводка
    /// </summary>
    public string Summary { get; set; }

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Тип события
    /// </summary>
    public IssueTypeEnum Type { get; set; }

    /// <summary>
    /// Статус
    /// </summary>
    public IssueStatusEnum Status { get; set; }

    /// <summary>
    /// Приоритет события
    /// </summary>
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
    /// Дата создания события
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// Дата крайнего срока завершения события
    /// </summary>
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// Ссылки на эпик
    /// </summary>
    public int? EpicLink { get; set; }

    /// <summary>
    /// Списанное время
    /// </summary>
    public virtual ICollection<TimeTracking> TimeTrackings { get; set; }

    /// <summary>
    /// Ссылка на sprints
    /// </summary>
    public virtual ICollection<Sprint> Sprints { get; set; }

    public Issue()
    {
        TimeTrackings = new List<TimeTracking>();
    }

}

public class IssueConfiguration : IEntityTypeConfiguration<Issue>
{
    public void Configure(EntityTypeBuilder<Issue> builder)
    {
        builder
            .HasIndex(u => u.Id)
            .IsUnique();
        builder
            .Property(e => e.DueDate)
            .HasColumnType("Date");
    }
}