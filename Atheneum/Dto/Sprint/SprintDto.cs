using Atheneum.Dto.Issue;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atheneum.Dto.Sprint
{
    /// <summary>
    /// Таблица спринтов
    /// </summary>
    public class SprintDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Дата начала спринта
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Дата окончания спринта
        /// </summary>
        public DateTime FinishtDate { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public byte IsEnded { get; set; }

        /// <summary>
        /// Ссылка на issues
        /// </summary>
        public List<IssueDto> Issues { get; set; }

        public class SprintIssuesDto
        {
            public long SprintId { get; set; }
            public SprintDto Sprint { get; set; }

            public long IssueId { get; set; }
            public IssueDto Issue { get; set; }
        }

    }
}
