using Atheneum.Dto.TimeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atheneum.Interface
{
    public interface ITimeTracking
    {
        /// <summary>
        /// Создать 
        /// </summary>
        Task<long> Create(TimeTrackingDto model);

        /// <summary>
        /// Получить детали
        /// </summary>
        Task<TimeTrackingDto> Details(long Id);

        /// <summary>
        /// Изменить
        /// </summary>
        Task Update(TimeTrackingDto model);

        /// <summary>
        /// Удалить
        /// </summary>
        Task Delete(long Id);

        /// <summary>
        /// Получить список
        /// </summary>
        Task<IEnumerable<TimeTrackingDto>> GetList();

    }
}
