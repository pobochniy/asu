using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Atheneum.EntityDeployment;

public class DeploymentServer
{
    [Key]
    public Guid Id { get; set; }
    
    [MaxLength(100)]
    public string Alias { get; set; }
    
    [MaxLength(300)]
    public string Description { get; set; }
    
    [MaxLength(100)]
    public string Label { get; set; }
    
    [StringLength(15)]    
    public string Ip { get; set; }
    
    [MaxLength(100)]
    public string SshUser { get; set; }
    
    [MaxLength(100)]
    public string SshPassword { get; set; } 
    
    public virtual ICollection<TrustedUser> TrustedUsers { get; set; } = new List<TrustedUser>();
    
    public virtual ICollection<DeploymentLog> Logs { get; set; } = new List<DeploymentLog>();
    
    public virtual ICollection<KeyVault> KeyVaults { get; set; } = new List<KeyVault>();
}