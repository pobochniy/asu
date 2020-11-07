using Atheneum.Dto.Auth;
using Atheneum.Dto.Chat;
using Atheneum.Enums;
using Atheneum.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Web.SignalR;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IHubContext<ChatHub, IChatHub> _hub;
        private readonly IAuthService service;

        public AuthController(IAuthService service, IHubContext<ChatHub, IChatHub> hubContext)
        {
            this.service = service;
            this._hub = hubContext;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await service.Register(model);
                    var user = await service.LogIn(new LoginDto { Login = model.UserName, Password = model.Password });

                    await _hub.Clients.All.SysMessages(new SysMessagesDto { Type = ChatTypeEnum.user, Data = user });

                    return Ok(user);
                }

                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> LogIn([FromBody] LoginDto model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await service.LogIn(model);
                    await SignInAsync(user);

                    return Ok(user);
                }
                catch (UnauthorizedAccessException)
                {
                    ModelState.AddModelError("", "Неправильное имя пользователя или пароль");
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("[action]")]
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
                claims.Add(new Claim(ClaimTypes.Role, ((int)role).ToString()));
            }

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));
        }
    }
}