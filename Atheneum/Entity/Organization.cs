using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atheneum.Entity
{
    public class Organization
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; }

        public string Description { get; set; }

        public Guid? ParentId { get; set; }

        public int Level { get; set; }

        //public Organization Parent { get; set; }
    }

    //public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    //{
    //    public void Configure(EntityTypeBuilder<Organization> builder)
    //    {
    //        builder
    //            .HasOne(sc => sc.Parent)
    //            .WithOne(s => s.Parent)
    //            .HasForeignKey(sc => sc.ParentId);
    //    }
    //}
}
