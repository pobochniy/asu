using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Atheneum.Dto.Epic;
using Atheneum.Enums;
using FunctionalTests.Arranges;
using Xunit;
using FunctionalTests.Asserts;

namespace FunctionalTests.Controllers;

public class Epic
{
    [Fact]
    public async Task Details()
    {
        Assert.False(true); //test gha work
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

    [Fact]
    public async Task Create_Validation()
    {
        // Arrange
        var admin = Given.Admin();
        var client = await Given.ApiClient(x => x.Profiles.Add(admin));
        var emptyEpicDto = new EpicDto();

        // Act
        var response = await client.PostAsJsonAsync<EpicDto>("/api/Epic/Create", emptyEpicDto);

        // Assert
        await response.ShouldBeValidation(new[] {"Name"});
    }

    [Fact]
    public async Task Delete()
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
        var response = await client.PostAsJsonAsync("/api/Epic/Delete", epic.Id);

        // Assert
        await response.ShouldBeSuccessful();
    }

    [Fact]
    public async Task Update()
    {
        // Arrange
        var admin = Given.Admin();
        var epic = Given.Epic(admin.Id);
        var vlad = Given.Vlad(new List<RoleEnum>() {RoleEnum.epicCrud});

        var client = await Given.ApiClient(x =>
        {
            x.Profiles.Add(admin);
            x.Epic.Add(epic);
            x.Profiles.Add(vlad);
        });
        var epicDto = new EpicDto
        {
            Id = epic.Id,
            Assignee = vlad.Id,
            Reporter = vlad.Id,
            Priority = IssuePriorityEnum.low,
            Name = "Эпик по захвату мира",
            Description = "Полное описание",
            DueDate = new DateTime(2050, 12, 31)
        };

        // Act
        var response = await client.PostAsJsonAsync<EpicDto>("/api/Epic/Update", epicDto);

        // Assert
        await response.ShouldBeSuccessful();
        var detailsResponse = await client.GetAsync("/api/Epic/Details?id=42");
        await detailsResponse.ShouldBeSuccessful();
        var detailsResult = await detailsResponse.Content.ReadFromJsonAsync<EpicDto>();
        detailsResult.AssertEquals(epicDto);
    }

    [Fact]
    public async Task Update_Validation()
    {
        // Arrange
        var admin = Given.Admin();
        var epic = Given.Epic(admin.Id);

        var client = await Given.ApiClient(x =>
        {
            x.Profiles.Add(admin);
            x.Epic.Add(epic);
        });
        var epicDto = new EpicDto();

        // Act
        var response = await client.PostAsJsonAsync<EpicDto>("/api/Epic/Update", epicDto);

        // Assert
        await response.ShouldBeValidation(new[] {"Name"});
    }

    [Fact]
    public async Task GetList()
    {
        // Arrange
        var admin = Given.Admin();
        var epic = Given.Epic(admin.Id);
        var epic2 = Given.Epic(admin.Id, 1);
        var epic3 = Given.Epic(admin.Id, 2);

        var client = await Given.ApiClient(x =>
        {
            x.Profiles.Add(admin);
            x.Epic.Add(epic);
            x.Epic.Add(epic2);
            x.Epic.Add(epic3);
        });

        // Act
        var response = await client.GetAsync("/api/Epic/GetList");

        // Assert
        await response.ShouldBeSuccessful();
        var result = await response.Content.ReadFromJsonAsync<IEnumerable<EpicDto>>();
        Assert.True(result.Count() == 3);
        result.Single(x => x.Id == 42).AssertEquals(epic);
    }
}