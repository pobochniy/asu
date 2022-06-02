using Atheneum.Dto.CashFlow;
using Atheneum.Extentions.Auth;
using Atheneum.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]/[action]")]
[Authorize]
public class CashFlowController : ControllerBase
{
    private readonly ICashFlowService _service;

    public CashFlowController(ICashFlowService context)
    {
        _service = context;
    }

    [HttpGet]
    public async Task<IActionResult> Details([FromQuery] Guid id)
    {
        var res = await _service.Details(id);
        return Ok(res);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(Guid? userId)
    {
        var res = await _service.GetList(userId);
        return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CashFlowDto dto)
    {
        dto.UserIdPassed = User.GetUserId();

        if (!ModelState.IsValid) return UnprocessableEntity(ModelState);

        try
        {
            var id = await _service.Create(dto);
            return Ok(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}