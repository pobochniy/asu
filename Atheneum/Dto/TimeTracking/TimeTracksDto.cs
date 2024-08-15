using System;

namespace Atheneum.Dto.TimeTracking;

public class TimeTracksDto
{
    public TimeOnly From { get; set; }
    public TimeOnly To { get; set; }
    public string Comment { get; set; }
    public long? IssueId { get; set; }
    public int? EpicId { get; set; }
}