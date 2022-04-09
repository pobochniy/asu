using Atheneum.Entity;
using FunctionalTests.Arranges;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace FunctionalTests;

public class FunctionalTestsApiApplication : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        var root = new InMemoryDatabaseRoot();

        builder.ConfigureServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<ApplicationContext>));
            services.AddDbContext<ApplicationContext>(options =>
                options.UseInMemoryDatabase("Testing", root));

            var sp = services.BuildServiceProvider();

            using var scope = sp.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<ApplicationContext>();
            db.Database.EnsureCreated();
            var arranges = new ArrangeUsers();
            arranges.CreateSuperAdmin(db);
        });

        return base.CreateHost(builder);
    }
}