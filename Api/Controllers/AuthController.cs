using Atheneum.Dto.Auth;
using Atheneum.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Api.SignalR;
using Atheneum.Dto.Chat;
using Atheneum.Enums;
using Microsoft.AspNetCore.SignalR;

namespace Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[AllowAnonymous]
public class AuthController : ControllerBase
{
    private readonly IHubContext<ChatHub, IChatHub> _hub;
    private readonly IAuthService service;

    public AuthController(IAuthService service, IHubContext<ChatHub, IChatHub> hubContext)
    {
        this.service = service;
        this._hub = hubContext;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterDto model)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await service.Register(model);
            var user = await service.LogIn(new LoginDto {Login = model.UserName, Password = model.Password});

            await _hub.Clients.All.SysMessages(new SysMessagesDto { Type = ChatTypeEnum.user, Data = user });

            return Ok(user);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPost]
    public async Task<IActionResult> LogIn([FromBody] LoginDto model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            var user = await service.LogIn(model);
            await SignInAsync(user);

            return Ok(user);
        }
        catch (UnauthorizedAccessException)
        {
            ModelState.AddModelError("", "Неправильное имя пользователя или пароль");
            return BadRequest(ModelState);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return Ok();
    }

    private async Task SignInAsync(UserDto user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName)
        };

        foreach (var role in user.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, ((int) role).ToString()));
        }

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(identity));
    }
}