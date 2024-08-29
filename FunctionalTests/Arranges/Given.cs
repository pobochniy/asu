using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Atheneum.Entity;
using Atheneum.Enums;
using FunctionalTests.ArrangeEntityBuilders;

namespace FunctionalTests.Arranges;

public static class Given
{
    public static async Task<HttpClient> ApiClient(Action<ApplicationContext>? dbArrange = null)
    {
        var client = await new ApiApplicationFactory<Program>()
            .SetupApplication(dbArrange, Guid.NewGuid().ToString());
        return client;
    }
    
    public static Profile Admin()
    {
        return new UserBuilder(UserBuilder.SuperAdminName, UserBuilder.SuperAdminEmail, UserBuilder.SuperAdminPhone)
            .WithAllRoles()
            .Please();
    }
    
    public static Profile Vlad(ICollection<RoleEnum> roles)
    {
        return new UserBuilder(UserBuilder.VladName, UserBuilder.VladEmail, UserBuilder.VladPhone)
            .WithRoles(roles)
            .Please();
    }

    public static Epic Epic(Guid userId, int? epicId = null)
    {
        return new EpicBuilder()
            .WithId(epicId)
            .WithAssignee(userId)
            .WithReporter(userId)
            .Please();
    } 
}