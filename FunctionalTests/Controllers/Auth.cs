using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Atheneum.Dto.Auth;
using FunctionalTests.ArrangeEntityBuilders;
using FunctionalTests.Arranges;
using FunctionalTests.Asserts;
using Xunit;

namespace FunctionalTests.Controllers;

public class Auth
{
    [Fact]
    public async Task CreateUser()
    {
        // Assert
        var usr = ArrangeUsers.Vlad;
        var client = await new ApiApplicationFactory<Program>().SetupApplication(null, Guid.NewGuid().ToString(), false);

        // Act
        var response = await client.PostAsJsonAsync<RegisterDto>("/api/Auth/Register", usr);

        // Assert
        await response.ShouldBeSuccessful();
        var result = await response.Content.ReadFromJsonAsync<UserDto>();
        Assert.True(result.UserName == usr.UserName, "UserName");
        Assert.True(result.Id != Guid.Empty, "UserId");
    }

    [Theory]
    [InlineData("admin")]
    [InlineData("admin@test.ru")]
    [InlineData("+79091112233")]
    public async Task Login(string adminLogin)
    {
        // Arrange
        var admin = Given.Admin();
        
        var client = await new ApiApplicationFactory<Program>()
            .SetupApplication(x => x.Profiles.Add(admin), Guid.NewGuid().ToString(), false);
        
        var loginModel = new LoginDto
        {
            Login = adminLogin,
            Password = UserBuilder.SuperAdminPassword
        };

        // Act
        var response = await client.PostAsJsonAsync<LoginDto>("/api/Auth/Login", loginModel);

        // Assert
        await response.ShouldBeSuccessful();
        var result = await response.Content.ReadFromJsonAsync<UserDto>();
    }
}