using Microsoft.AspNetCore.Mvc;
using SkiProject.Core.Models;

namespace SkiProject.Controllers
{
    public class ResortController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Bansko()
        {
            LocationViewModel model = new LocationViewModel()
            {
                Title = "Bansko",
                Description = "Bansko,Bulgaria",
                Latitude = 41.8429765,
                Longitude = 23.4849658
            };
            return View(model);
        }
    }
}
