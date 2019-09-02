using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Atheneum.Entity.Identity;
using Atheneum.Interface;
using Atheneum.Services;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        private readonly IRolesService _service;

        public RolesController(IRolesService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var res = await _service.GetRoles();
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> AddRole(string RoleName)
        {
            if (!string.IsNullOrWhiteSpace(RoleName))
            {
                try
                {
                    var res = await _service.AddRole(RoleName);
                    return Ok(res);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateRole([FromBody]Role Role)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var res = await _service.UpdateRole(Role);
                    return Ok(res);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> DeleteRole(Guid RoleId)
        {
            try
            {
                await _service.DeleteRole(RoleId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
    }
}