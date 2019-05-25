﻿using Atheneum.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;

namespace Atheneum.Entity.Identity
{
    /// <summary>
    /// Таблица с общим чатом
    /// </summary>
    public class ChatRoom
    {
        [Key]
        public long Id { get; set; }

        public RoomEnum Room { get; set; }

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
                .HasIndex(u => u.Room)
                .IsUnique();
        }
    }
}
