using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Atheneum.Entity;

/// <summary>
/// Таблица спринтов
/// </summary>
public class Sprint
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Key]
    public long Id { get; set; }

    /// <summary>
    /// Дата начала спринта
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Дата окончания спринта
    /// </summary>
    public DateTime FinishDate { get; set; }

    /// <summary>
    /// Статус
    /// </summary>
    public byte IsEnded { get; set; }

    /// <summary>
    /// Ссылка на issues
    /// </summary>
    public List<Issue> Issues { get; set; }
}

public class SprintConfiguration : IEntityTypeConfiguration<Sprint>
{
    public void Configure(EntityTypeBuilder<Sprint> builder)
    {
        builder
            .Property(e => e.FinishDate)
            .HasColumnType("Date");

        builder
            .Property(e => e.StartDate)
            .HasColumnType("Date");

        builder
            .HasMany(s => s.Issues)
            .WithMany(i => i.Sprints)
            .UsingEntity<SprintIssues>(
                x => x.HasOne(xs => xs.Issue).WithMany(),
                x => x.HasOne(xs => xs.Sprint).WithMany())
            .HasKey(x => new { x.SprintId, x.IssueId });

        builder.HasIndex(x => x.StartDate).IsUnique();

        builder.HasIndex(x => x.FinishDate).IsUnique();
    }
}