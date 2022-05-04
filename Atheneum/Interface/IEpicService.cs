using Atheneum.Dto.Epic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atheneum.Interface
{
    public interface IEpicService
    {
        /// <summary>
        /// Создать 
        /// </summary>
        Task<int> Create(EpicDto model);

        /// <summary>
        /// Получить детали
        /// </summary>
       Task<EpicDto> Details(int id);

        /// <summary>
        /// Изменить
        /// </summary>
        Task Update(EpicDto model);

        /// <summary>
        /// Удалить
        /// </summary>
        Task Delete(int id);

        /// <summary>
        /// Получить список
        /// </summary>
        Task<IEnumerable<EpicDto>> GetList();
    }
}
