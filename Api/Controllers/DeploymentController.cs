using System.Text;
using Atheneum.Dto.Deployment;
using Atheneum.Interface;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DeploymentController : ControllerBase
    {
        private readonly IDeploymentService _service;

        public DeploymentController(IDeploymentService service)
        {
            _service = service;
        }
        
        [HttpPost]
        public async Task<IActionResult> ImageMetadataSave([FromBody]ImageMetadataDto dto)
        {
            return Ok();
        }
        
        [HttpGet]
        public async Task<IActionResult> ImageMetadataList()
        {
            var res = await _service.GetImages();
            return Ok(res);
        }
        
        [HttpPost]
        public async Task<IActionResult> ImageMetadataDelete([FromBody]Guid id)
        {
            return Ok();
        }
        
    }
}