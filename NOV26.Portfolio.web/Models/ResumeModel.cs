using System.ComponentModel.DataAnnotations.Schema;

namespace NOV26.Portfolio.web.Models;

public class ResumeModel
{
    public int Id { get; set; }
    [Column(name:"START_YEAR")]
    public int StartYear { get; set; }
    [Column(name:"END_YEAR")]
    public int EndYear { get; set; }
    [Column(name:"TITLE")]
    public string Title { get; set; }
    [Column(name:"INSTITUTION_NAME")]
    public string InstitutionName { get; set; }
    [Column(name:"DESC")]
    public string Description { get; set; }
}