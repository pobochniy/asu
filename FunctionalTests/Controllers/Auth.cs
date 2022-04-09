using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Atheneum.Dto.Auth;
using FunctionalTests.Arranges;
using FunctionalTests.Asserts;
using Xunit;

namespace FunctionalTests.Controllers;

public class Auth : IClassFixture<FunctionalTestsApiApplication>
{
    private readonly HttpClient _client;

    public Auth(FunctionalTestsApiApplication factory)
    {
        _client = factory.CreateClient();
        //_factory = new FunctionalTestsApiApplication();
        //     factory.WithWebHostBuilder(builder =>
        // {
        //     builder.ConfigureServices(services =>
        //     {
        //     });
        // });
        //.CreateClient();
    }

    [Fact]
    public async Task CreateUser()
    {
        var usr = new RegisterDto
        {
            UserName = "pob",
            Email = "pob@email.ru",
            Phone = "+79091112234",
            Password = "123", 
            PasswordConfirm = "123"
        };

        // Act
        var response = await _client.PostAsJsonAsync<RegisterDto>("/api/Auth/Register", usr);

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
    public async Task Login(string login)
    {
        // Arrange
        var loginModel = new LoginDto
        {
            Login = login,
            Password = ArrangeUsers.SuperAdminPassword
        };

        // Act
        var response = await _client.PostAsJsonAsync<LoginDto>("/api/Auth/Login", loginModel);

        // Assert
        await response.ShouldBeSuccessful();
        var result = await response.Content.ReadFromJsonAsync<UserDto>();
    }
}