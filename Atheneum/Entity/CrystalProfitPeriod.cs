using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Atheneum.Entity;

/// <summary>
/// Периоды фиксирования заработанных кристаллов (обычно ежемесячные)
/// </summary>
public class CrystalProfitPeriod
{
    [Key]
    public int Id { get; set; }
    
    public DateOnly From { get; set; }
    
    public DateOnly To { get; set; }
    
    public DateTime Created { get; set; }
    
    public Guid UserCreated { get; set; }
    
    public virtual ICollection<CrystalPayment> Payments { get; set; }
}