using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SubscribeController(HttpClient http) : Controller
    {
        private readonly HttpClient _http = http;

        [HttpPost]
        public async Task<IActionResult> Subscribe(SubscribeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = await _http.PostAsync("https://localhost:7146/api/Subscribers?key=de94fdf1-37f4-40cd-b634-8a9367b98c1a", content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["Status"] = "You are now subscribed";
                    return RedirectToAction("Home", "Default", "subscribe");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    TempData["Status"] = "You are already subscribed!";
                    return RedirectToAction("Home", "Default", "subscribe");
                }
            }

            TempData["Status"] = "Something went wrong";
            return RedirectToAction("Home", "Default", "subscribe");
        }
    }
}