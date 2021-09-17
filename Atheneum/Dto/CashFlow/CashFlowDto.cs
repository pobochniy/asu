using System;
using System.Collections.Generic;
using System.Text;

namespace Atheneum.Dto.CashFlow
{
    public class CashFlowDto
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Кто передал деньги
        /// </summary>
        public Guid UserIdPassed { get; set; }

        /// <summary>
        /// Кто принял деньги
        /// </summary>
        public Guid UserIdReceived { get; set; }

        /// <summary>
        /// Количество средств
        /// </summary>
        public decimal Cash { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }
    }
}
