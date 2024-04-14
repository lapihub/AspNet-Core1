using Infrastructure.Data.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, HttpClient http, IConfiguration configuration) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;
    private readonly HttpClient _http = http;
    private readonly IConfiguration _configuration = configuration;

    #region SignUp

    [HttpGet]
    [Route("/signup")]
    public IActionResult SignUp()
    {
        return View();
    }


    [HttpPost]
    [Route("/signup")]
    public async Task<IActionResult> SignUp(SignUpForm form)
    {
        if (ModelState.IsValid)
        {
            try
            {
                if ((await _userManager.CreateAsync(UserFactory.Create(form), form.Password)).Succeeded)
                {
                    if ((await _signInManager.PasswordSignInAsync(form.Email, form.Password, false, false)).Succeeded)
                    {
                        return RedirectToAction("Details", "Account");
                    }
                }
                else
                {
                    ViewData["StatusMessage"] = "User with the same email address already exists";
                }
            }
            catch
            {
                ViewData["StatusMessage"] = "An unexpected error occurred. Please try again.";
            }
        }

        return View(form);
    }


    #endregion

    #region SignIn

    [HttpGet]
    [Route("/signin")]
    public IActionResult SignIn(string returnUrl)
    {
        ViewData["ReturnUrl"] = returnUrl ?? "/";
        return View();
    }


    [HttpPost]
    [Route("/signin")]
    public async Task<IActionResult> SignIn(SignInForm form, string returnUrl)
    {
        if (ModelState.IsValid)
        {
            try
            {
                if ((await _signInManager.PasswordSignInAsync(form.Email, form.Password, form.IsPresistent, false)).Succeeded)
                    return LocalRedirect(returnUrl);
            }
            catch
            {
                ViewData["StatusMessage"] = "An unexpected error occurred. Please try again.";
            }
        }

        ViewData["StatusMessage"] = "Incorrect email or password";
        return View(form);
    }

    #endregion

    #region Sign Out

    [HttpGet]
    [Route("/signout")]

    public new async Task<IActionResult> SignOut()
    {
        Response.Cookies.Delete("AccessToken");
        await _signInManager.SignOutAsync();
        return LocalRedirect("/");
    }

    #endregion
}