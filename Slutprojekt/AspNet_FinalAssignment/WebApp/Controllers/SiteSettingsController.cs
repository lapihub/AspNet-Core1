using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class SiteSettingsController : Controller
{
 
    public IActionResult Consent()
    {
        var option = new CookieOptions
        {
            Expires = DateTime.Now.AddYears(1),
            HttpOnly = true,
            Secure = true
        };
        Response.Cookies.Append("consent", "true", option);
        return Ok();
    }
}