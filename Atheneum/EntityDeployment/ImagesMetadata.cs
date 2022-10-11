using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Atheneum.EntityDeployment;

public class ImagesMetadata
{
    [Key]
    public Guid Id { get; set; }
    
    public DateTime UtcDate { get; set; }
    
    [MaxLength(100)]
    public string GitHubUser { get; set; }
    
    [MaxLength(100)]
    public string BranchName { get; set; } 
    
    [MaxLength(100)]    
    public string DockerHubAccount { get; set; }
    
    [MaxLength(100)]    
    public string DockerHubRepository { get; set; }
    
    [MaxLength(100)]    
    public string DockerTag { get; set; }
    
    public virtual ICollection<DeploymentLog> Logs { get; set; } = new List<DeploymentLog>();
}