using System.Net.Http.Json;
using System.Threading.Tasks;
using Atheneum.Dto.Epic;
using FunctionalTests.Arranges;
using Xunit;
using FunctionalTests.Asserts;

namespace FunctionalTests.Controllers;

public class Epic
{
    [Fact]
    public async Task Details()
    {
        // Arrange
        var admin = Given.Admin();
        var epic = Given.Epic(admin.Id);

        var client = await Given.ApiClient(x =>
        {
            x.Profiles.Add(admin);
            x.Epic.Add(epic);
        });
        
        // Act
        var response = await client.GetAsync("/api/Epic/Details?id=42");

        // Assert
        await response.ShouldBeSuccessful();
        var result = await response.Content.ReadFromJsonAsync<EpicDto>();
        result.AssertEquals(epic);
    }

    [Fact]
    public async Task Create()
    {
        // Arrange
        var admin = Given.Admin();
        var client = await Given.ApiClient(x => x.Profiles.Add(admin));
        var epicDto = ArrangeEpics.TestEpic;
        
        // Act
        var response = await client.PostAsJsonAsync<EpicDto>("/api/Epic/Create", epicDto);

        // Assert
        await response.ShouldBeSuccessful();
        var result = await response.Content.ReadAsStringAsync();
        var epicId = int.Parse(result);
    }

}