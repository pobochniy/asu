using Atheneum.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FunctionalTests;

public class ApiApplicationFactory<TStartup> : WebApplicationFactory<TStartup>
    where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<ApplicationContext>));
            // services.AddDbContext<ApplicationContext>(options =>
            //     options.UseInMemoryDatabase("Testing"));
            //
            // // var contextOptions = new DbContextOptionsBuilder<ApplicationContext>().UseInMemoryDatabase("Testing").Options; 
            // // services.AddSingleton(contextOptions);
            //
            // var sp = services.BuildServiceProvider();
            //
            // using var scope = sp.CreateScope();
            // var scopedServices = scope.ServiceProvider;
            // var db = scopedServices.GetRequiredService<ApplicationContext>();
            // db.Database.EnsureCreated();

            //ArrangeUsers.CreateSuperAdmin(db);
        });
    }
}

public class GenericWebApplicationFactory<TStartup, TSeed>
    : WebApplicationFactory<TStartup>
    where TStartup : class
    where TSeed : class, ISeedDataClass
{
    private readonly string _dbName;

    public GenericWebApplicationFactory(string dbName = "InMemoryDbForTesting")
    {
        _dbName = dbName;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        //base.ConfigureWebHost(builder);
        //builder.UseEnvironment("Development");
        builder.ConfigureServices(services =>
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            //services.RemoveAll(typeof(DbContextOptions<ApplicationContext>));


            services.RemoveAll(typeof(DbContextOptions<ApplicationContext>));
            services.AddTransient<ISeedDataClass, TSeed>();

            services.AddDbContextPool<ApplicationContext>(options =>
            {
                options.UseInMemoryDatabase(_dbName);
                options.UseInternalServiceProvider(serviceProvider);
                options.EnableSensitiveDataLogging();
            });

            var sp = services
                .BuildServiceProvider();
            // services.AddDbContext<ApplicationContext>(options =>
            //     options.UseInMemoryDatabase("Testing"));


            using var scope = sp.CreateScope();
            var scopedServices = scope.ServiceProvider;
            // var db = scopedServices.GetRequiredService<ApplicationContext>();
            // ArrangeUsers.CreateSuperAdmin(db);

            var seeder = scopedServices.GetRequiredService<ISeedDataClass>();
            seeder.InitializeDbForTests();

            // var sp = services.BuildServiceProvider();
            // using (var scope = sp.CreateScope())
            // {
            //     var scopedServices = scope.ServiceProvider;
            //     var db = scopedServices.GetRequiredService<TContext>();
            //     // var logger = scopedServices
            //     //     .GetRequiredService<ILogger<GenericWebApplicationFactory<TStartup, TContext, TSeed>>>();
            //
            //     var seeder = scopedServices.GetRequiredService<ISeedDataClass>();
            //
            //     db.Database.EnsureCreated();
            //
            //     seeder.InitializeDbForTests();
            // }
        });
    }
}

public interface ISeedDataClass
{
    void InitializeDbForTests();
}

public class SeedEpics : ISeedDataClass
{
    private readonly ApplicationContext _db;

    public SeedEpics(ApplicationContext db)
    {
        _db = db;
    }

    public void InitializeDbForTests()
    {
        // ArrangeUsers.CreateSuperAdmin(_db);
        // if (_db.Epic.Any()) return;
        //
        // var epic = ArrangeEpics.EntityTestEpic;
        // _db.Epic.Add(epic);
        // _db.SaveChanges(true);
    }
}

public class SeedEmpty : ISeedDataClass
{
    private readonly ApplicationContext _db;

    public SeedEmpty(ApplicationContext db)
    {
        _db = db;
        _db.Database.EnsureDeleted();
        _db.Database.EnsureCreated();
    }
    
    public void InitializeDbForTests()
    {
        //ArrangeUsers.CreateSuperAdmin(_db);
    }
}