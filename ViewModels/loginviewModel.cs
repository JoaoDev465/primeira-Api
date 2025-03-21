using System.ComponentModel.DataAnnotations;

namespace MyloginViewModels;

public class loginViewModel
{
    [EmailAddress(ErrorMessage ="o Email inválido ")]
    [GmailValidation]
    public string Email { get; set; }

    [Required (ErrorMessage = "o campo é obrigatório")]
    public string Password { get; set; }


    public class GmailValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var Email = value as string;

            if (Email != null && Email.EndsWith("@Gmail.com",StringComparison.OrdinalIgnoreCase))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage = "Email inválido, tente novamente , Ex: SeuEmail@gmail.com");
        }
    }
    
   
}
