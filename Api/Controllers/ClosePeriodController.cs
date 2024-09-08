using Api.Middleware;
using Atheneum.Dto.ClosePeriod;
using Atheneum.Enums;
using Atheneum.Extentions.Auth;
using Atheneum.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]/[action]")]
[Authorize]
public class ClosePeriodController: ControllerBase
{
    private readonly ClosePeriodService _service;

    public ClosePeriodController(ClosePeriodService service)
    {
        _service = service;
    }

    [HttpPost]
    [AuthorizeRoles(RoleEnum.finPeriodEdit)]
    public async Task<IActionResult> Calculate([FromBody]DatePeriodDto dto)
    {
        if(!ModelState.IsValid) return UnprocessableEntity(ModelState);
        await _service.Calculate(dto, User.GetUserId());
        return Ok();
    }
    
    [HttpGet]
    [AuthorizeRoles(RoleEnum.finPeriodEdit, RoleEnum.finPeriodRead)]
    public async Task<IActionResult> GetList()
    {
        var res = await _service.GetList();
        return Ok(res);
    }
}