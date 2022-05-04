using System;
using Atheneum.Dto.Epic;
using Atheneum.Enums;

namespace FunctionalTests.Arranges;

public static class ArrangeEpics
{
    public static readonly EpicDto TestEpic = new EpicDto
    {
        Id = 42,
        // Assignee = ArrangeUsers.SuperAdmin.Id,
        // Reporter = ArrangeUsers.SuperAdmin.Id,
        Priority = IssuePriorityEnum.high,
        Name = "Тестовый эпик",
        Description = "Ребята решили протестировать санни дей на эпик",
        DueDate = new DateTime(2007, 1, 1)
    };
}