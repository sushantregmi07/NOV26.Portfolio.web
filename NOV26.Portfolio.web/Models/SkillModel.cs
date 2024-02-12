using System.ComponentModel.DataAnnotations;

namespace NOV26.Portfolio.web.Models;

public class SkillModel
{
    [Key] 
    public int Id { get; set; }
    [StringLength(50)]
    public string Name { get; set; }
    [Range(10,100)]
    public decimal SkillPct { get; set; }
}