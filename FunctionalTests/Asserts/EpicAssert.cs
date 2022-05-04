using Atheneum.Dto.Epic;
using Atheneum.Entity;
using Xunit;

namespace FunctionalTests.Asserts;

public static class EpicAssert
{
    public static void AssertEquals(this EpicDto dto, Epic entity, bool withId = true)
    {
        if(withId) Assert.True(dto.Id == entity.Id, "Id");
        Assert.True(dto.Assignee == entity.Assignee, "Assignee");
        Assert.True(dto.Reporter == entity.Reporter, "Reporter");
        Assert.True(dto.Priority == entity.Priority, "Priority");
        Assert.True(dto.Name == entity.Name, "Name");
        Assert.True(dto.Description == entity.Description, "Name");
        Assert.True(dto.DueDate == entity.DueDate, "DueDate");
    }
}