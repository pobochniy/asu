using System;

namespace Atheneum.Dto.ClosePeriod;

public class CrystalPaymentDto
{
    public int Id { get; set; }

    public Guid UserId { get; set; }
    public decimal Cash { get; set; }
}