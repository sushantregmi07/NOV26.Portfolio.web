using System.ComponentModel.DataAnnotations;

namespace NOV26.Portfolio.web.Models;

public class UserModel
{
    public int Id { get; set; }
    [EmailAddress]
    public string UserName { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
}