using System;
using Atheneum.Enums;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atheneum.Entity.Identity
{
    public class Issue
    {
        [Key]
        public long Id { get; set; } 

        public Guid? Assignee { get; set; }        

        public string Reporter { get; set; }  

        public string Summary { get; set; }         

        public string Description { get; set; }     

        public IssueTypeEnum Type { get; set; }  

        public IssueStatusEnum Status { get; set; } 

        public IssuePriorityEnum Priority { get; set; } 

        public decimal? AssigneeEstimatedTime { get; set; }

        public decimal? ReporterEstimatedTime { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? DueDate { get; set; }

        public string EpicLink { get; set; }

    }

    public class IssueConfiguration : IEntityTypeConfiguration<Issue>
    {
        
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder
               .HasIndex(u => u.Id)
               .IsUnique();     
        }
            
    }
} 
