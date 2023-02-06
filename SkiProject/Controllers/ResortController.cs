using BingMapsRESTToolkit;
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



        public async Task<IActionResult> BanskoMainPage()
        {
            LocationViewModel model1 = new LocationViewModel()
            {
                Title = "Bansko",
                Description = "Bansko,Bulgaria",
                Latitude = 41.8429765,
                Longitude = 23.4849658
            };
           
            ResortViewModel model = new ResortViewModel(){ Name = "Bansko" };

            var resort = await resortService.GetCurrentResort(model.Name);
            var slope = await resortService.GetSlope(resort.Id);
            model.Slope= slope;
            model.CameraUrl = resort.WebCamera;
            model.Description = "Bansko,Bulgaria";
            HttpContext.Response.Cookies.Append("visited_resort", "Bansko");
            return View(model);
        }

        public async Task<IActionResult> PamporovoMainPage()
        {
            LocationViewModel model1 = new LocationViewModel()
            {
                Title = "Bansko",
                Description = "Bansko,Bulgaria",
                Latitude = 41.8429765,
                Longitude = 23.4849658
            };

            ResortViewModel model = new ResortViewModel() { Name = "Pamporovo" };
            var resort = await resortService.GetCurrentResort(model.Name);
            var slope = await resortService.GetSlope(resort.Id);
            model.Slope = slope;
            model.CameraUrl = resort.WebCamera;
            model.Description = "Pamporovo,Bulgaria";

            HttpContext.Response.Cookies.Append("visited_resort", "Pamporovo");
            return View(model);
        }
        public async Task<IActionResult> BorovetsMainPage()
        {
            LocationViewModel model1 = new LocationViewModel()
            {
                Title = "Bansko",
                Description = "Bansko,Bulgaria",
                Latitude = 41.8429765,
                Longitude = 23.4849658
            };

            ResortViewModel model = new ResortViewModel() { Name = "Borovets" };
            var resort = await resortService.GetCurrentResort(model.Name);
            var slope = await resortService.GetSlope(resort.Id);
            model.Slope = slope;
            model.CameraUrl = resort.WebCamera;
            model.Description = "Borovets,Bulgaria";

            HttpContext.Response.Cookies.Append("visited_resort", "Borovets");
            return View(model);
        }
        public async Task<IActionResult> PanichishteMainPage()
        {
            LocationViewModel model1 = new LocationViewModel()
            {
                Title = "Bansko",
                Description = "Bansko,Bulgaria",
                Latitude = 41.8429765,
                Longitude = 23.4849658
            };

            ResortViewModel model = new ResortViewModel() { Name = "Panichishte" };
            var resort = await resortService.GetCurrentResort(model.Name);
            var slope = await resortService.GetSlope(resort.Id);
            model.Slope = slope;
            model.CameraUrl = resort.WebCamera;
            model.Description = "Panichishte,Bulgaria";
            HttpContext.Response.Cookies.Append("visited_resort", "Panichishte");
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
        
    }
}
