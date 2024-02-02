using System.ComponentModel.DataAnnotations;

namespace NOV26.Portfolio.web.Models;

public class PersonalInformationModel
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Address { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    [DataType(DataType.Date)]
    public DateTime DOB { get; set; }
    public string Email { get; set; }
    public string ZipCode { get; set; }
    public string Phone { get; set; }
    public int CompletedProjects { get; set; }
    [Required(AllowEmptyStrings = true)] 
    public string UserPhotoUrl { get; set; } = "";

}