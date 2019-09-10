using Atheneum.Dto.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atheneum.Interface
{
    public interface IIssue
    {

        /// <summary>
        /// Создать событие
        /// </summary>
        Task<long> Create(IssueDto model);

        /// <summary>
        /// Получить информацию о событии
        /// </summary>
        Task<IssueDto> Details(long id);

        /// <summary>
        /// Изменить событие
        /// </summary>
        Task Update(IssueDto model);

        /// <summary>
        /// Удалить событие
        /// </summary>
        Task Delete(long id);

        /// <summary>
        /// Получить список событий
        /// </summary>
        Task<IEnumerable<IssueDto>> GetList();

    }
}
