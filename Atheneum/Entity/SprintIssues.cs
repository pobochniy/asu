namespace Atheneum.Entity;

/// <summary>
/// Таблица связей sprint - issue
/// </summary>
public class SprintIssues
{
    public long SprintId { get; set; }
    public virtual Sprint Sprint { get; set; }

    public long IssueId { get; set; }
    public virtual Issue Issue { get; set; }
}