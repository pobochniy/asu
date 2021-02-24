using Atheneum.Dto.Epic;
using Atheneum.Entity.Identity;
using Atheneum.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atheneum.Service
{
    public class EpicService : IEpic
    {
        private ApplicationContext db;

        public EpicService(ApplicationContext context)
        {
            db = context;
        }

        public async Task<int> Create(EpicDto dto)
        {
            var epic = new Epic
            {
                Assignee = dto.Assignee,
                Reporter = dto.Reporter,
                Priority = dto.Priority,
                Name = dto.Name,
                Description = dto.Description,
                DueDate = dto.DueDate
            };
            await db.Epic.AddAsync(epic);
            await db.SaveChangesAsync();
            return epic.Id;
        }

        public async Task<EpicDto> Details(int id)
        {
            if (id == 0) return new EpicDto();

            var epic = await db.Epic.FindAsync(id);
            var epicdto = new EpicDto
            {
                Id = epic.Id,
                Assignee = epic.Assignee,
                Reporter = epic.Reporter,
                Priority = epic.Priority,
                Name = epic.Name,
                Description = epic.Description,
                DueDate = epic.DueDate
            };
            return epicdto;
        }

        public async Task Update(EpicDto epicDto)
        {
            var epic = await db.Epic.FindAsync(epicDto.Id);
            epic.Assignee = epicDto.Assignee;
            epic.Reporter = epicDto.Reporter;
            epic.Priority = epicDto.Priority;
            epic.Name = epicDto.Name;
            epic.Description = epicDto.Description;
            epic.DueDate = epicDto.DueDate;

            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var i = await db.Epic.FindAsync(id);
            db.Epic.Remove(i);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<EpicDto>> GetList()
        {
            var epic = await db.Epic.Select(x => new EpicDto
            {
                Id = x.Id,
                Assignee = x.Assignee,
                Reporter = x.Reporter,
                Priority = x.Priority,
                Name = x.Name,
                Description = x.Description,
                DueDate = x.DueDate
            }).ToArrayAsync();
            return epic;
        }
    }
}
