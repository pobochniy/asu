using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;

namespace Atheneum.Entity
{
    /// <summary>
    /// Модель для фиксации почасовой ставки сотрудника
    /// </summary>
    public class HourlyPay
    {
        /// <summary>
        /// Id Ставки
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// ID работника
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Дата начала действия ставки
        /// </summary>
        public DateTime StartedDate { get; set; }

        /// <summary>
        /// Стоимость часа сотрудника
        /// </summary>
        public decimal Cash { get; set; }

        /// <summary>
        /// Id пользователя создавшего запись 
        /// </summary>
        public Guid UserIdCreated { get; set; }

        /// <summary>
        /// Дата создания записи
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }

    public class HourlyPayConfiguration : IEntityTypeConfiguration<HourlyPay>
    {
        public void Configure(EntityTypeBuilder<HourlyPay> builder)
        {
            builder
              .HasIndex(u => u.Id);
            builder
                .Property(e => e.StartedDate)
                .HasColumnType("Date");
        }
    }
}
