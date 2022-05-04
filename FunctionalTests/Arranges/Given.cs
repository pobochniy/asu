using System;
using System.Net.Http;
using System.Threading.Tasks;
using Atheneum.Entity;
using FunctionalTests.ArrangeEntityBuilders;

namespace FunctionalTests.Arranges;

public static class Given
{
    public static async Task<HttpClient> ApiClient(Action<ApplicationContext>? dbArrange = null)
    {
        var client = await new ApiApplicationFactory<Program>().SetupApplication(dbArrange, Guid.NewGuid().ToString());
        return client;
    }
    
    public static Profile Admin()
    {
        return new UserBuilder(UserBuilder.SuperAdminName, UserBuilder.SuperAdminEmail, UserBuilder.SuperAdminPhone)
            .WithAllRoles()
            .Please();
    }

    public static Epic Epic(Guid userId)
    {
        return new EpicBuilder()
            .WithAssignee(userId)
            .WithReporter(userId)
            .Please();
    } 
}