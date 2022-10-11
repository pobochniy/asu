using System;

namespace Atheneum.Dto.Deployment;

public class ImageMetadataDto
{
    public Guid Id { get; set; }
    
    public DateTime Date { get; set; }
    
    public DockerHubMetadataDto DockerHubData { get; set; }
    
    public GitHubMetadataDto GitHubData { get; set; }
}