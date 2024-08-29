using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atheneum.Entity;

public class CrystalPayment
{
    [Key] 
    public int Id { get; set; }

    public Guid UserId { get; set; }
    public decimal Cash { get; set; }
    public int CrystalProfitPeriodId { get; set; }
    public virtual CrystalProfitPeriod CrystalProfitPeriod { get; set; }
}

public class CrystalPaymentConfiguration : IEntityTypeConfiguration<CrystalPayment>
{
    public void Configure(EntityTypeBuilder<CrystalPayment> builder)
    {
        builder
            .HasOne(sc => sc.CrystalProfitPeriod)
            .WithMany(s => s.Payments)
            .HasForeignKey(sc => sc.CrystalProfitPeriodId);
    }
}