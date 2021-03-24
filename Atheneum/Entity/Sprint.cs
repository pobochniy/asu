﻿using Atheneum.Entity.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atheneum.Entity
{
    /// <summary>
    /// Таблица спринтов
    /// </summary>
    public class Sprint
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Дата начала спринта
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Дата окончания спринта
        /// </summary>
        public DateTime FinishtDate { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public byte IsEnded { get; set; }

        /// <summary>
        /// Ссылка на issues
        /// </summary>
        public List<Issue> Issues { get; set; }

        public class SprintConfiguration : IEntityTypeConfiguration<Sprint>
        {
            public void Configure(EntityTypeBuilder<Sprint> builder)
            {
                builder
                    .HasIndex(u => u.Id)
                    .IsUnique();
                builder
                    .Property(e => e.FinishtDate)
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

                builder.HasIndex(x => x.FinishtDate).IsUnique();
            }
        }
    }
}