using System.ComponentModel.DataAnnotations;

namespace Presentation.WebApp.Helpers;

public class CheckboxRequired : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        return value is bool b && b;
    }

    // vi tar värdet, kontrollerar att det är ett bool värde och att det boolvärdet är true (b=b)
}