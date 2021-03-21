using Atheneum.Dto.Sprint;
using Atheneum.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atheneum.Interface
{
    public interface ISprint
    {
        /// <summary>
        /// Создать спринт
        /// </summary>
        Task<long> Create(SprintDto dto);

        /// <summary>
        /// Список спринтов
        /// </summary>
        public Task<IEnumerable<SprintDto>> GetList();

        /// <summary>
        /// Удалить спринт
        /// cascade delete автоматически
        /// </summary>
        public Task Delete(long Id);

        /// <summary>
        /// Получить спринт по Id
        /// </summary>
        public Task<SprintDto> Details(long? id);

        /// <summary>
        /// Обновить спринт
        /// </summary>
        public Task Update(SprintDto sprintdto);

        /// <summary>
        /// Добавить issues в спринт
        /// </summary>
        public Task AddIssue(long sprintId, long issueId);

        /// <summary>
        /// Удалить issue из спринт
        /// </summary>
        public Task DeleteIssue(long sprintId, long issueId);

        //todo:
        /// <summary>
        /// 
        /// </summary>
        public Task MoveIssueToNextSprint(long issueId);
    }
}
