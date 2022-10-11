using System.Collections.Generic;
using System.Threading.Tasks;
using Atheneum.EntityDeployment;

namespace Atheneum.Interface;

public interface IDeploymentService
{
    Task<IEnumerable<ImagesMetadata>> GetImages();
}