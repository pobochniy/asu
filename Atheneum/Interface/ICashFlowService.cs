using Atheneum.Dto.CashFlow;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atheneum.Interface
{
    public interface ICashFlowService
    {
        /// <summary>
        /// Создать событие
        /// </summary>
        Task<Guid> Create(CashFlowDto model);

        /// <summary>
        /// Получить информацию о событии
        /// </summary>
        Task<CashFlowDto> Details(Guid id);

        /// <summary>
        /// Изменить событие
        /// </summary>
        //Task Update(CashFlowDto model);

        /// <summary>
        /// Удалить событие
        /// </summary>
        //Task Delete(Guid id);

        /// <summary>
        /// Получить список событий
        /// </summary>
        Task<IEnumerable<CashFlowDto>> GetList(Guid? userId);
    }
}
