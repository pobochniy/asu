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
                Reporter = dto.Reporter,
                PriorityEnum = dto.PriorityEnum,
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
            var epic = await db.Epic.FindAsync(id);
            var epicdto = new EpicDto
            {
                Id = epic.Id,
                Reporter = epic.Reporter,
                PriorityEnum = epic.PriorityEnum,
                Name = epic.Name,
                Description = epic.Description,
                DueDate = epic.DueDate
            };
            return epicdto;
        }

        public async Task Update(EpicDto epicDto)
        {
            var epic = await db.Epic.FindAsync(epicDto.Id);
            epic.Reporter = epicDto.Reporter;
            epic.PriorityEnum = epicDto.PriorityEnum;
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
                Reporter = x.Reporter,
                PriorityEnum = x.PriorityEnum,
                Name = x.Name,
                Description = x.Description,
                DueDate = x.DueDate
            }).ToArrayAsync();
            return epic;
        }
    }
}
