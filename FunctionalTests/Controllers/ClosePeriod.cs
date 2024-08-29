using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Atheneum.Dto.ClosePeriod;
using Atheneum.Entity;
using FunctionalTests.ArrangeEntityBuilders;
using FunctionalTests.Arranges;
using FunctionalTests.Asserts;
using Xunit;

namespace FunctionalTests.Controllers;

public class ClosePeriod
{
    [Fact]
    public async Task Calculate()
    {
        // Arrange
        var closePeriodDto = new DatePeriodDto
        {
            From = new DateOnly(2007, 8, 1),
            To = new DateOnly(2007, 8, 31)
        };
        var admin = new UserBuilder(UserBuilder.SuperAdminName,
                UserBuilder.SuperAdminEmail,
                UserBuilder.SuperAdminPhone)
            .WithAllRoles()
            .WithHourlyPay(new DateOnly(2007, 7, 30), 10)
            .WithHourlyPay(new DateOnly(2007, 8, 15), 20)
            .WithTimeTracking(closePeriodDto.From, new TimeOnly(8, 0), new TimeOnly(18, 0))
            .WithTimeTracking(closePeriodDto.To, new TimeOnly(8, 0), new TimeOnly(18, 0))
            .Please();
        
        var client = await Given.ApiClient(x => { x.Profiles.Add(admin); });


        // Act
        var response = await client.PostAsJsonAsync("/api/ClosePeriod/Calculate", closePeriodDto);

        // Assert
        await response.ShouldBeSuccessful();
        var periodsResponse =
            await client.GetFromJsonAsync<IEnumerable<CrystalProfitPeriod>>("/api/ClosePeriod/GetList");
        Assert.True(periodsResponse.Count() == 1, "Failed for get created period");
        var profiles = await client.GetFromJsonAsync<IEnumerable<Profile>>("/api/Users/GetProfiles");
        Assert.True(profiles.Single().Cash == 300,
            $"The user's salary was not added (current={profiles.Single().Cash})");
    }
}