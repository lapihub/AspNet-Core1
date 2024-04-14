using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class DefaultController : Controller
{

    [Route("/")] //ändrar sökvägen till Home webbläsaren
    public IActionResult Home()
    {
        return View();
    }

}
