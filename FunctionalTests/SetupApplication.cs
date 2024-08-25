using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Atheneum.Dto.Auth;
using Atheneum.Entity;
using FunctionalTests.ArrangeEntityBuilders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace FunctionalTests;

public static class SetupApplicationExt
{
    public static async Task<HttpClient> SetupApplication(this ApiApplicationFactory<Program> factory,
        Action<ApplicationContext>? dbArrange = null, string dbName = "", bool withAuth = true)
    {
        var client = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddDbContext<ApplicationContext>(options =>
                    options
                        .UseInMemoryDatabase("Testing_" + dbName)
                        .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                    );

                var sp = services.BuildServiceProvider();

                using var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<ApplicationContext>();
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                if (dbArrange != null) dbArrange(db);
                db.SaveChanges();
            });
        }).CreateClient();

        if (withAuth)
        {
            var usr = new LoginDto
            {
                Login = UserBuilder.SuperAdminName,
                Password = UserBuilder.SuperAdminPassword
            };
            await client.PostAsJsonAsync("/api/Auth/Login", usr);
        }

        return client;
    }
}