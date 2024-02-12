using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NOV26.Portfolio.web.Models;

public class BlogCommentModel
{
    [Key] 
    public int Id { get; set; }
    public string Name { get; set; }
    public string Comment { get; set; }
    [ValidateNever]
    public DateTime DateOfComment { get; set; }=DateTime.Now;
    [ForeignKey(nameof(Blog))]
    public int BlogId { get; set; }
    [ValidateNever]
    public virtual BlogModel Blog { get; set; }
    
}