using Infrastructure.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

[Authorize]
public class DefaultController(DataContext context) : Controller
{
    private readonly DataContext _context = context;

    [AllowAnonymous]
    public IActionResult Home()
    {
        return View();
    }

}
