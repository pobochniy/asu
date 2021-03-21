using Atheneum.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atheneum.Entity
{
    public class SprintIssues
    {
        public long SprintId { get; set; }
        public virtual Sprint Sprint { get; set; }

        public long IssueId { get; set; }
        public virtual Issue Issue { get; set; }
    }
}
