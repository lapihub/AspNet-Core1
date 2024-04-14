using System.ComponentModel.DataAnnotations;

namespace Presentation.WebApp.Helpers;

public class CheckboxRequired : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        return value is bool b && b;
    }
}