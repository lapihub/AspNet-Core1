using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class SignUpViewModel
{
    [Display(Name = "First name", Prompt = "Enter your first name")]
    [Required(ErrorMessage = "A valid first name is required")]
    [MinLength(2, ErrorMessage = "A valid first name is required")]
    public string FirstName { get; set; } = null!;


    [Display(Name = "Last name", Prompt = "Enter your last name")]
    [Required(ErrorMessage = "A valid last name is required")]
    [MinLength(2, ErrorMessage = "A valid last name is required")]
    public string LastName { get; set; } = null!;


    [Display(Name = "Email address", Prompt = "Enter your email address")]
    [Required(ErrorMessage = "An valid email address is required")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;


    [Display(Name = "Password", Prompt = "Enter your password")]
    [Required(ErrorMessage = "A valid password is required")]
    [MinLength(8, ErrorMessage = "A valid password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;


    [Display(Name = "Confirm password", Prompt = "Confirm your password")]
    [Required(ErrorMessage = "Password must be confirmed")]
    [Compare(nameof(Password), ErrorMessage = "Passwords don't match")]
    [DataType(DataType.Password)]
    public string ConfirmPassword {  get; set; } = null!;


    [Display(Name = "I agree to the Terms & Conditions.")]
    [Required(ErrorMessage = "Terms and conditions must be accepted")]
    public bool TermsAndConditions { get; set; }

}
