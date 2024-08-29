using System;
using System.Collections.Generic;

namespace Atheneum.Dto.ClosePeriod;

public class CrystalProfitPeriodDto
{
    public int Id { get; set; }
    
    public DateOnly From { get; set; }
    
    public DateOnly To { get; set; }
    
    public DateTime Created { get; set; }
    
    public Guid UserCreated { get; set; }
    
    public IEnumerable<CrystalPaymentDto> Payments { get; set; }
}