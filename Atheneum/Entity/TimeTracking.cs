using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;

namespace Atheneum.Entity;

/// <summary>
/// Модель страницы учета личного времени
/// </summary>
public class TimeTracking
{

    /// <summary>
    /// Уникальный номер записи
    /// </summary>
    [Key]
    public long Id { get; set; }

    /// <summary>
    /// Системная дата
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// День на который списывать время
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Время "с"
    /// </summary>
    public DateTime From { get; set; }

    /// <summary>
    /// Время "по"
    /// </summary>
    public DateTime To { get; set; }

    /// <summary>
    /// Описание работы
    /// </summary>
    public string Comment { get; set; }

    /// <summary>
    /// Пользователь, потративший время
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Задача, на которую потрачено время
    /// </summary>
    public long? IssueId { get; set; }

    /// <summary>
    /// Эпик, на который потрачено время
    /// </summary>
    public int? EpicId { get; set; }

    public virtual User User { get; set; }

    public virtual Issue Issue { get; set; }

    public virtual Epic Epic { get; set; }
}

public class TimeTrackingConfiguration : IEntityTypeConfiguration<TimeTracking>
{
    public void Configure(EntityTypeBuilder<TimeTracking> builder)
    {
        builder
            .HasOne(sc => sc.User)
            .WithMany(s => s.TimeTrackings)
            .HasForeignKey(sc => sc.UserId);

        builder
            .HasOne(i => i.Issue)
            .WithMany(s => s.TimeTrackings)
            .HasForeignKey(sc => sc.IssueId);

        builder
            .HasOne(i => i.Epic)
            .WithMany(s => s.TimeTrackings)
            .HasForeignKey(sc => sc.EpicId);

    }
}