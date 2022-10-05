using System.Text;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class KokoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Hello()
        {
            return Content("Hello craft-hosting");
        }
    }
}