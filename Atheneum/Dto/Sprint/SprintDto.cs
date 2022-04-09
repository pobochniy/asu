using Atheneum.Dto.Issue;
using System;
using System.Collections.Generic;

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
        public DateTime FinishDate { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public byte IsEnded { get; set; }

        /// <summary>
        /// Ссылка на issues
        /// </summary>
        public List<IssueDto> Issues { get; set; }
    }
}
