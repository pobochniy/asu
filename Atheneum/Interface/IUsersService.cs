using Atheneum.Entity.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atheneum.Interface
{
    public interface IUsersService
    {
        Task<IEnumerable<Profile>> GetProfiles();
    }
}
