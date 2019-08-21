using Atheneum.Dto.Auth;
using Atheneum.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]")]

    public class IssueController : Controller
    {
        private readonly IIssue service;

        public IssueController(IIssue service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create([FromBody]IssueDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await service.Create(model);

                    return View(); // заглушка, чтобы солюшн пересобрался
                }

                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }


        }
    }
}

