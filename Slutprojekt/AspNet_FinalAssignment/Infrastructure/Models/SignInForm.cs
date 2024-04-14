using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class SignInForm
{
    [Required(ErrorMessage = "You must enter an e-mail address")]
    [Display(Name = "E-mail address", Prompt = "Enter your e-mail address")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a password")]
    [Display(Name = "Password", Prompt = "Enter your password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Display(Name = "Remember me")]
    public bool IsPresistent { get; set; }
}