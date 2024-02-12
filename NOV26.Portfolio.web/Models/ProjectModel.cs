using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NOV26.Portfolio.web.Models;

public class ProjectModel
{
    [Key]
    public int Id { get; set; }

    public int Width { get; set; }

    public string Title { get; set; }
    
    public string ClientName { get; set; }
    [ValidateNever]
    public string ProjectImageUrl { get; set; }
    
    public int ServiceId { get; set; }
    [ValidateNever]
    public virtual ServiceModel Service { get; set; }
    
}