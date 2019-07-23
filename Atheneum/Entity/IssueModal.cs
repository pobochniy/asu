using System;
using Atheneum.Enums;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atheneum.Entity.Identity
{
    public class IssueModal
    {
        [Key]
        public long IssueID { get; set; } 

        public string Director { get; set; }        

        public string Executor { get; set; }        

        public string Reporters { get; set; }       

        public string Summary { get; set; }         

        public string Description { get; set; }     


        public IssueTypeEnum Type { get; set; }  

        public IssueStatusEnum Status { get; set; } 

        public IssuePriorityEnum Priority { get; set; } 


        public int DirectorEstimatedTime { get; set; }

        public int ExecutorEstimatedTime { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime DeadlineDate { get; set; }

        public int TimeSpent { get; set; }

        
        public string Attachment { get; set; }

        public string EpicLink { get; set; }

        public string OtherLinks { get; set; }
    }

    public class IssueConfiguration : IEntityTypeConfiguration<IssueModal>
    {
        
        public void Configure(EntityTypeBuilder<IssueModal> builder)
        {
            builder
               .HasIndex(u => u.IssueID)
               .IsUnique();     
        }
            
    }
} 
