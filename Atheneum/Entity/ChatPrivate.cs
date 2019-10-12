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
        /// <summary>
        /// Время сообщения
        /// </summary>
        public long Tick { get; set; }

        /// <summary>
        /// Кто написал сообщение
        /// </summary>
        public Guid SenderId { get; set; }

        /// <summary>
        /// Адресат
        /// </summary>
        public Guid ReceiverId { get; set; }

        /// <summary>
        /// Тип сообщения
        /// </summary>
        public ChatTypeEnum Type { get; set; }

        /// <summary>
        /// Кто написал сообщение
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Адресаты из кому, переджоиненые символом '#'
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Адресаты из привата, переджоиненые символом '#'
        /// </summary>
        public string Privat { get; set; }

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
