using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MyRoles;
using SecureIdentity.Password;

namespace MyUserView;

public class UserView
{   [Required(ErrorMessage = "O nome é obrigatório")]
    public string Name { get; set; }

    [Required(ErrorMessage = "o Email é obrigatório")]
    [EmailAddress]
    public 	string Email { get; set; }
    
    public string Slug { get; set; }


  

    
}