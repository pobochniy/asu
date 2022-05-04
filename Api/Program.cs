using Api.Middleware;
using Atheneum.Entity;
using Atheneum.Services;
using Atheneum.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var config = builder.Configuration;

services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
    {
        o.Cookie.HttpOnly = true;
        o.Events = new CookieAuthenticationEvents
        {
            OnRedirectToLogin = redirectContext =>
            {
                redirectContext.HttpContext.Response.StatusCode = 401;
                return Task.CompletedTask;
            }
        };
    });

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var connString = config.GetConnectionString("AppConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
services.AddDbContext<ApplicationContext>(opt => opt.UseMySql(
    connString,
    serverVersion,
    x => x.MigrationsAssembly("Atheneum")
));

services.AddTransient<RolesValidation>();
services.AddTransient<IAuthService, AuthService>();
services.AddTransient<IChatService, ChatService>();
services.AddTransient<IIssue, IssueService>();
services.AddTransient<IUsersService, UsersService>();
services.AddTransient<IEpicService, EpicServiceService>();
services.AddTransient<ISprint, SprintService>();
services.AddTransient<ITimeTracking, TimeTrackingService>();
services.AddHttpContextAccessor();

services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { /* Expose the Program class for use with WebApplicationFactory<T> */ }