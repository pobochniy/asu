using Atheneum.Entity.Identity;
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

        public class SprintIssues
        {
            public long SprintId { get; set; }
            public Sprint Sprint { get; set; }

            public long IssueId { get; set; }
            public Issue Issue { get; set; }
        }

        public class SprintConfiguration : IEntityTypeConfiguration<Sprint>
        {
            public void Configure(EntityTypeBuilder<Sprint> builder)
            {
                builder
                    .HasIndex(u => u.Id)
                    .IsUnique();
                builder //в Issue так же)
                    .Property(e => e.FinishtDate)
                    .HasColumnType("Date");

                builder //в Issue так же)
                    .Property(e => e.StartDate)
                    .HasColumnType("Date");
            }
        }
    }
}
