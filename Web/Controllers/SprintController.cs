﻿using Atheneum.Dto.Sprint;
using Atheneum.Enums;
using Atheneum.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Middleware;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SprintController : Controller
    {
        private readonly ISprint service;

        public SprintController(ISprint service)
        {
            this.service = service;
        }

        [HttpGet("[action]")]
        [AuthorizeRoles(RoleEnum.sprintCrud, RoleEnum.epicRead)]
        public async Task<IEnumerable<SprintDto>> GetList()
        {
            return await service.GetList();
        }

        [HttpPost("[action]")]
        [AuthorizeRoles(RoleEnum.sprintCrud)]
        public async Task<IActionResult> Create([FromBody] SprintDto model)
        {
            try 
            {
                // TODO: Вынести валидацию в модель 
                if (ModelState.IsValid)
                {
                    var id = await service.Create(model);

                    return Ok(id);
                }
                return BadRequest(ModelState);
            }
            catch(ArgumentException)
            {
                return BadRequest(ModelState); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("[action]")]
        [AuthorizeRoles(RoleEnum.sprintCrud)]
        public async Task<IActionResult> Delete(long id)
        {
            await service.Delete(id);
            return Ok(id);
        }

        [HttpGet("[action]")]
        [AuthorizeRoles(RoleEnum.sprintCrud, RoleEnum.sprintRead)]
        public async Task<SprintDto> Details(long id)
        {
            return await service.Details(id);
        }

        [HttpPost("[action]")]
        [AuthorizeRoles(RoleEnum.sprintCrud)]
        public async Task<IActionResult> Update([FromBody] SprintDto issuedto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await service.Update(issuedto);

            var res = await service.Details(issuedto.Id);
            return Ok(res);
        }

        [HttpGet("[action]")]
        [AuthorizeRoles(RoleEnum.sprintCrud)]
        public async Task<IActionResult> AddIssue(long sprintId, long issueId)
        {
            await service.AddIssue(sprintId, issueId);
            return Ok(sprintId);
        }

        [HttpGet("[action]")]
        [AuthorizeRoles(RoleEnum.sprintCrud)]
        public async Task<IActionResult> DeleteIssue(long sprintId, long issueId)
        {
            await service.DeleteIssue(sprintId, issueId);
            return Ok(sprintId);
        }
    }
}
