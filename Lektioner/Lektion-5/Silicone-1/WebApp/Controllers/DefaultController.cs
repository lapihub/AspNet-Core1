using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;


public class DefaultController(DataContext context) : Controller
{
    private readonly DataContext _context = context;

    public IActionResult Home()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Subscribe(SubscribeViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var subscriberEntity = new SubscriberEntity
            {
                Email = viewModel.Email,
                DailyNewsletter = viewModel.DailyNewsletter,
                AdvertisingUpdates = viewModel.AdvertisingUpdates,
                WeekinReview = viewModel.WeekinReview,
                EventUpdates = viewModel.EventUpdates,
                StartupsWeekly = viewModel.StartupsWeekly,
                Podcasts = viewModel.Podcasts
            };

            _context.Subscribers.Add(subscriberEntity);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Default", "Home");
    }

}
