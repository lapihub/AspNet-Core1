using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class ErrorsController : Controller
{
    [Route("/not-found")]
    public IActionResult NotFound()
    {
        return View();
    }

    [Route("/denied")]
    public IActionResult Denied()
    {
        return View();
    }
}