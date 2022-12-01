using Microsoft.AspNetCore.Mvc;
using SkiProject.Core.Contracts;
using SkiProject.Core.Models;

namespace SkiProject.Controllers
{
    public class ResortController : BaseController
    {
        private readonly IResortService resortService;
        public ResortController(IResortService _resortService)
        {
            this.resortService = _resortService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult BanskoMainPage()
        {
            LocationViewModel model1 = new LocationViewModel()
            {
                Title = "Bansko",
                Description = "Bansko,Bulgaria",
                Latitude = 41.8429765,
                Longitude = 23.4849658
            };
            ResortViewModel model = new ResortViewModel(){ Name = "Bansko" };
            HttpContext.Response.Cookies.Append("visited_resort", "Bansko");
            return View();
        }

        public IActionResult PamporovoMainPage()
        {
            LocationViewModel model1 = new LocationViewModel()
            {
                Title = "Bansko",
                Description = "Bansko,Bulgaria",
                Latitude = 41.8429765,
                Longitude = 23.4849658
            };

            ResortViewModel model = new ResortViewModel() { Name = "Pamporovo" };

            HttpContext.Response.Cookies.Append("visited_resort", "Pamporovo");
            return View();
        }
        public IActionResult BorovetsMainPage()
        {
            LocationViewModel model1 = new LocationViewModel()
            {
                Title = "Bansko",
                Description = "Bansko,Bulgaria",
                Latitude = 41.8429765,
                Longitude = 23.4849658
            };

            ResortViewModel model = new ResortViewModel() { Name = "Borovets" };

            HttpContext.Response.Cookies.Append("visited_resort", "Borovets");
            return View();
        }
        public IActionResult PanichishteMainPage()
        {
            LocationViewModel model1 = new LocationViewModel()
            {
                Title = "Bansko",
                Description = "Bansko,Bulgaria",
                Latitude = 41.8429765,
                Longitude = 23.4849658
            };

            ResortViewModel model = new ResortViewModel() { Name = "Panichishte" };

            HttpContext.Response.Cookies.Append("visited_resort", "Panichishte");
            return View();
        }

        public async Task<IActionResult> GetSlopePage()
        {
            var lastVisitedResort = HttpContext.Request.Cookies["visited_resort"];
            var resort = await resortService.GetCurrentResort(lastVisitedResort);
            var slope = await resortService.GetSlope(resort.Id);
            ResortViewModel model = new ResortViewModel() { Name = lastVisitedResort,Slope=slope };
            return View(model);
        }

        public async Task<IActionResult> GetPlacesToStay()
        {
            var lastVisitedResort = HttpContext.Request.Cookies["visited_resort"];
            var resort =await resortService.GetCurrentResort(lastVisitedResort);
            var placesToStay =  await resortService.GetAllPlacesToStayInCurrentResort(resort.Id);
            ResortViewModel model = new ResortViewModel() { PlacesToStay=placesToStay,Name=lastVisitedResort };
            return View(model);
        }
        public async Task<IActionResult> GetWebCamera()
        {
            var lastVisitedResort = HttpContext.Request.Cookies["visited_resort"];
            var resort = await resortService.GetCurrentResort(lastVisitedResort);
            var cameraUrl = resort.WebCamera;
            return Redirect(cameraUrl);
        }
    }
}
