using System;
using Atheneum.Entity;
using Atheneum.Enums;

namespace FunctionalTests.ArrangeEntityBuilders;

public class EpicBuilder
{
    private Epic _epic;

    public EpicBuilder()
    {
        _epic = new Epic
        {
            Id = 42,
            Priority = IssuePriorityEnum.high,
            Name = "Тестовый эпик",
            Description = "Ребята решили протестировать санни дей на эпик",
            DueDate = new DateTime(2007, 1, 1)
        };
    }

    public EpicBuilder WithAssignee(Guid userId)
    {
        _epic.Assignee = userId;

        return this;
    }

    public EpicBuilder WithReporter(Guid userId)
    {
        _epic.Reporter = userId;

        return this;
    }

    public Epic Please()
    {
        return _epic;
    }
}