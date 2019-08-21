using Atheneum.Dto.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atheneum.Interface
{
    public interface IIssue
    {
        // Получить список событий
        Task<IEnumerable<IssueDto>> GetList();

        /// <summary>
        /// Создать событие
        /// </summary>
        Task<long> Create (IssueDto model);

        /// <summary>
        /// Получить информацию о событии
        /// </summary>
        Task<IssueDto> Details(IssueDto model);

        // Изменить событие
        Task Update(IssueDto model);

        // Удалить событие
        Task Delete(IssueDto model);
    }
}
