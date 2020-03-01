using Atheneum.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atheneum.Entity.Identity
{
    public class Epic
    {
        [Key]
        public int Id { get; set; }
        public Guid? Reporter { get; set; }
        public IssuePriorityEnum PriorityEnum { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}

