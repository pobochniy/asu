using Atheneum.Dto.HourlyPay;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atheneum.Interface
{
    public interface IHourlyPayService
    {
        /// <summary>
        /// Создать событие
        /// </summary>
        Task<int> Create(HourlyPayDto model);

        /// <summary>
        /// Получить информацию о событии
        /// </summary>
        Task<HourlyPayDto> Details(int Id);

        /// <summary>
        /// Изменить событие
        /// </summary>
        Task Update(HourlyPayDto model);

        /// <summary>
        /// Удалить событие
        /// </summary>
        Task Delete(int Id);

        /// <summary>
        /// Получить список событий
        /// </summary>
        Task<IEnumerable<HourlyPayDto>> GetList(Guid? userId);
    }
}
