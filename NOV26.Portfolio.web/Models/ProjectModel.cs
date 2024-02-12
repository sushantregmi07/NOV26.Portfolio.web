using System.ComponentModel.DataAnnotations;

namespace NOV26.Portfolio.web.Models;

public class ProjectModel
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; }
    
    public string ClientName { get; set; }
    
    public int ServiceId { get; set; }
    
    public virtual ServiceModel Service { get; set; }
    
}