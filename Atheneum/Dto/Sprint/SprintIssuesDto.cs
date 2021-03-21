using Atheneum.Dto.Issue;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atheneum.Dto.Sprint
{
    public class SprintIssuesDto
    {
        public long SprintId { get; set; }
        public SprintDto Sprint { get; set; }

        public long IssueId { get; set; }
        public IssueDto Issue { get; set; }
    }
}
