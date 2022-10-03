using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("/")]
    public class HomeController : ControllerBase
    {
        public HomeController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Content("Hello, <a href='/swagger'>Api</a>", "text/html");
        }
    }
}