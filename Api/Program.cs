using Api.Middleware;
using Api.Middleware.Converters;
using Atheneum.Entity;
using Atheneum.Services;
using Atheneum.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Metrics;


var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var config = builder.Configuration;

services.AddCors(c => c.AddPolicy("AllowSpecificOrigin", corsBuilder =>
{
    corsBuilder
        .WithOrigins("http://localhost:3000")
        .AllowCredentials()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

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

services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
        options.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
    });
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
services.AddTransient<UsersService>();
services.AddTransient<HourlyPayService>();
services.AddTransient<IEpicService, EpicServiceService>();
services.AddTransient<ISprint, SprintService>();
services.AddTransient<TimeTrackingService>();
services.AddTransient<ClosePeriodService>();
services.AddHttpContextAccessor();

services.AddSignalR();

services.AddOpenTelemetryMetrics(b =>
{
    b.AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation()
        .AddRuntimeMetrics(options =>
        {
            options.AssembliesEnabled = true;
            options.GcEnabled = true;
            options.JitEnabled = true;
            options.ProcessEnabled = true;
            options.ThreadingEnabled = true;
        })
        .AddPrometheusExporter();
});

var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseOpenTelemetryPrometheusScrapingEndpoint();
// app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowSpecificOrigin");

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{
    /* Expose the Program class for use with WebApplicationFactory<T> */
}