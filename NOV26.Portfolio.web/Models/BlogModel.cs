using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NOV26.Portfolio.web.Models;

public class BlogModel
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; }
    [ValidateNever]
    public string ImageUrl { get; set; }
    public string Paragraph1 { get; set; }
    public string Paragraph2 { get; set; }
    [ValidateNever]
    public DateTime DateTime { get; set; } = DateTime.Now;

}