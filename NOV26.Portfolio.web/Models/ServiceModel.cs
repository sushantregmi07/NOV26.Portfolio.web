using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NOV26.Portfolio.web.Models;

public class ServiceModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string Title { get; set; }
    [Required]
    
    public string Icon { get; set; }

    public string Description { get; set; }
}