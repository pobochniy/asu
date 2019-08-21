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
        Task<IssueDto> GetList();

        // Создать событие
        Task Create (IssueDto model);

        // Получить информацию о событии
        Task<IssueDto> Details(IssueDto model);

        // Изменить событие
        Task Update(IssueDto model);

        // Удалить событие
        Task Delete(IssueDto model);
    }
}
