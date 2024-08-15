using System;
using System.Linq;

namespace Atheneum.Dto.TimeTracking;

public class UserTimeTrackingDto
{
    // Дата в формате 2007-01-01
    public DateOnly Date { get; set; }

    // Списания за день
    public TimeTracksDto[] TimeTracks { get; set; }

    // Сумма списаний за день
    public string TotalTimeTracks
    {
        get
        {
            var totalMinutes = TimeTracks.Sum(x => (x.To - x.From).Minutes);
            
            return TimeSpan.FromMinutes(totalMinutes).ToString(@"hh\:mm");
        }
    }
}