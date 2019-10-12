using Atheneum.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;

namespace Atheneum.Entity.Identity
{
    /// <summary>
    /// Таблица с приватным чатом
    /// </summary>
    public class ChatPrivate
    {
        [Key]
        public long Tick { get; set; }

        /// <summary>
        /// Кто написал сообщение
        /// </summary>
        [Key]
        public Guid SenderId { get; set; }

        /// <summary>
        /// Адресат
        /// </summary>
        [Key]
        public Guid ReceiverId { get; set; }

        /// <summary>
        /// Сообщение
        /// </summary>
        public string Msg { get; set; }
    }

    public class ChatPrivateConfiguration : IEntityTypeConfiguration<ChatPrivate>
    {
        public void Configure(EntityTypeBuilder<ChatPrivate> builder)
        {
            builder.HasKey(k => new { k.Tick, k.SenderId, k.ReceiverId });

            builder.HasIndex(i => i.Tick);
        }
    }
}
