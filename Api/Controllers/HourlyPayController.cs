using Api.Middleware;
using Atheneum.Dto.HourlyPay;
using Atheneum.Enums;
using Atheneum.Extentions.Auth;
using Atheneum.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]/[action]")]
public class HourlyPayController : ControllerBase
{
    private readonly IHourlyPayService _service;

    public HourlyPayController(IHourlyPayService service)
    {
        this._service = service;
    }

    [HttpPost]
    [AuthorizeRoles(RoleEnum.hourlyPayCrud)]
    public async Task<IActionResult> Create([FromBody] HourlyPayDto model)
    {
        try
        {
            model.UserIdCreated = User.GetUserId();

            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);

            var id = await _service.Create(model);

            return Ok(id);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [AuthorizeRoles(RoleEnum.hourlyPayRead, RoleEnum.hourlyPayCrud)]
    public async Task<HourlyPayDto> Details(int id)
    {
        return await _service.Details(id);
    }

    [HttpGet]
    [AuthorizeRoles(RoleEnum.hourlyPayRead, RoleEnum.hourlyPayCrud)]
    public async Task<IEnumerable<HourlyPayDto>> GetList(Guid? userId)
    {
        return await _service.GetList(userId);
    }

    /*[HttpPost]
    [Route("[action]")]
    //[AuthorizeRoles(RoleEnum.hourlyPayCrud)]
    public async Task<IActionResult> Update([FromBody] HourlyPayDto hourlyPaydto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await service.Update(hourlyPaydto);

        var res = await service.Details(hourlyPaydto.Id);
        return Ok(res);
    }*/
}