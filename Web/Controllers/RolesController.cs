using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Atheneum.Entity.Identity;
using Atheneum.Interface;
using Atheneum.Service;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        private readonly IRolesService _service;

        public RolesController(IRolesService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<Role>> GetRoles()
        {
            IEnumerable<Role> res = await _service.GetRoles();
            return res;
        }
        
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> AddRole(string RoleName)
        {
            if(!string.IsNullOrWhiteSpace(RoleName))
            {
                Role role = await _service.AddRole(RoleName);
                return Ok(role);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateRole(Role Role)
        {
            if(ModelState.IsValid)
            {
                Role role = await _service.UpdateRole(Role);
                return Ok(Role);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> DeleteRole(Guid RoleId)
        {
            await _service.DeleteRole(RoleId);
            return Ok();
        }

        //// GET: api/Roles/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetRole([FromRoute] Guid id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var role = await _context.Roles.FindAsync(id);

        //    if (role == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(role);
        //}

        //// PUT: api/Roles/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutRole([FromRoute] Guid id, [FromBody] Role role)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != role.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(role).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RoleExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Roles
        //[HttpPost]
        //public async Task<IActionResult> PostRole([FromBody] Role role)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Roles.Add(role);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetRole", new { id = role.Id }, role);
        //}

        // DELETE: api/Roles/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteRole([FromRoute] Guid id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var role = await _context.Roles.FindAsync(id);
        //    if (role == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Roles.Remove(role);
        //    await _context.SaveChangesAsync();

        //    return Ok(role);
        //}

        //private bool RoleExists(Guid id)
        //{
        //    return _context.Roles.Any(e => e.Id == id);
        //}
    }
}