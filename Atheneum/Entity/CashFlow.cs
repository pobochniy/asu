using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;

namespace Atheneum.Entity
{
    public class CashFlow
    {
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Кто передал деньги
        /// </summary>
        public Guid UserIdPassed { get; set; }

        /// <summary>
        /// Кто принял деньги
        /// </summary>
        public Guid UserIdReceived { get; set; }

        /// <summary>
        /// Количество средств
        /// </summary>
        public decimal Cash { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }
    }

    public class CashFlowConfiguration : IEntityTypeConfiguration<CashFlow>
    {
        public void Configure(EntityTypeBuilder<CashFlow> builder)
        {
            builder
                .Property(x => x.Cash)
                .HasPrecision(18, 10);
        }
    }
}
