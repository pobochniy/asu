using Atheneum.Dto.CashFlow;
using Atheneum.Dto.Issue;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atheneum.Interface
{
    public interface ICashFlow
    {
        /// <summary>
        /// Создать событие
        /// </summary>
        Task<long> Create(CashFlowDto model);

        /// <summary>
        /// Получить информацию о событии
        /// </summary>
        Task<ICashFlow> Details(long? id);

        /// <summary>
        /// Изменить событие
        /// </summary>
        Task Update(ICashFlow model);

        /// <summary>
        /// Удалить событие
        /// </summary>
        Task Delete(long id);

        /// <summary>
        /// Получить список событий
        /// </summary>
        Task<IEnumerable<ICashFlow>> GetList(long? epicId);
    }
}
