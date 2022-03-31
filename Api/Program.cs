using Api.Middleware;
using Atheneum.Entity;
using Atheneum.Services;
using Atheneum.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var config = builder.Configuration;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

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
services.AddTransient<IEpic, EpicService>();
services.AddTransient<ISprint, SprintService>();
services.AddTransient<ITimeTracking, TimeTrackingService>();
services.AddHttpContextAccessor();

services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();