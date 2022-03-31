using Atheneum.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atheneum.Entity;

/// <summary>
/// Таблица с общим чатом
/// </summary>
public class ChatRoom
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public long Id { get; set; }

    public RoomEnum Room { get; set; }

    /// <summary>
    /// Тип сообщения
    /// </summary>
    public ChatTypeEnum Type { get; set; }

    /// <summary>
    /// Кто написал сообщение
    /// </summary>
    public string Login { get; set; }

    /// <summary>
    /// Адресаты из этой комнаты, переджоиненые символом '#'
    /// </summary>
    public string To { get; set; }

    /// <summary>
    /// Сообщение
    /// </summary>
    public string Msg { get; set; }
}

public class ChatRoomConfiguration : IEntityTypeConfiguration<ChatRoom>
{
    public void Configure(EntityTypeBuilder<ChatRoom> builder)
    {
        builder
            .HasIndex(u => u.Room);
    }
}