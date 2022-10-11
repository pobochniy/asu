using Atheneum.Dto.Epic;
using Atheneum.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atheneum.Dto.Deployment;
using Atheneum.Entity;
using Atheneum.EntityDeployment;

namespace Atheneum.Services
{
    public class DeploymentService : IDeploymentService
    {
        private DeploymentContext db;

        public DeploymentService(DeploymentContext context)
        {
            db = context;
        }

        public async Task<IEnumerable<ImagesMetadata>> GetImages()
        {
            var images = await db.DockerHubImages.ToArrayAsync();
            return images;
        }
    }
}
