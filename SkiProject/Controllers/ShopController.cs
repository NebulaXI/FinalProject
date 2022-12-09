using Ganss.Xss;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SkiProject.Core.Contracts;
using SkiProject.Core.Models;
using SkiProject.Core.Services;
using SkiProject.Infrastructure.Data.Models.Shop;
using System.Security.Claims;
using System.Web.Mvc;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using PartialViewResult = Microsoft.AspNetCore.Mvc.PartialViewResult;
using ViewResult = Microsoft.AspNetCore.Mvc.ViewResult;

namespace SkiProject.Controllers
{

    public class ShopController : BaseController
    {

        private readonly IShopService shopService;
        public ShopController(IShopService _shopService)
        {
            this.shopService = _shopService;
        }
        public async Task<IActionResult> Index()
        {
            var model = new AdvertismentsViewModel();
            var advretisments = await shopService.GetAllAdvertisments();
            var products = await shopService.GetAllProducts();
            var categories = await shopService.GetAllCategories();
            var genders = await shopService.GetAllGenders();
            //List<SelectListItem> items = new List<SelectListItem>();
            //foreach (var item in categories)
            //{
            //    items.Add(new SelectListItem() { Value = item.NameOfCategory });
            //}
            //ViewBag["CategoryName"] = items;
            model.Advertisments = advretisments; model.Products = products; model.Categories = categories; model.Genders = genders;

            return View(model);
        }

        public async Task<ViewResult> Index2(string value)
        {
            var model = new AdvertismentsViewModel();
            bool flag = true;
            var genders = await shopService.GetAllGenders();
            foreach (var item in genders)
            {
                if (value == item.NameOfGender)
                {
                    model.Products = await shopService.ProductsFilteredByGender(value);
                    model.Advertisments = await shopService.AdsFilteredByGender(value);
                    model.Categories = await shopService.GetAllCategories();
                    model.Genders = genders;
                    flag = false;
                }
            }
            if (flag)
            {
                model.Products = await shopService.ProductsFilteredByCategory(value);
                model.Advertisments = await shopService.AdsFilteredByCategory(value);
                model.Categories = await shopService.GetAllCategories();
                model.Genders = genders;
            }
            return View("~/Views/Shop/Index.cshtml", model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateNewProduct()
        {
            var model = new NewProductViewModel();
            return View(model);
        }
        //[HttpPost]
        //public async Task<IActionResult> CreateNewTopic(NewProductViewModel DTOModel)
        //{
        //    var sanitizer = new HtmlSanitizer();
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    var model = new NewProductViewModel()
        //    {
        //        CategoryId =,
        //        Category =,
        //        GenderId =,
        //        Gender =,
        //        Price =,
        //        Description =,
        //        ProductImages =
        //    };

        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    var topic = await postService.CreateTopic(model);
        //    await postService.AddNewTopic(topic);
        //    return RedirectToAction("Index");
        //}
    }
}
