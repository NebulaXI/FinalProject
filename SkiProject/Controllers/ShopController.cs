using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SkiProject.Core.Contracts;
using SkiProject.Core.Models;
using SkiProject.Infrastructure.Data.Models.Shop;
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
            model.Advertisments = advretisments;model.Products = products; model.Categories = categories;model.Genders=genders; 
            
            return View(model);
        }

        public async Task<ViewResult> Index2(string value)
        {
            var model = new AdvertismentsViewModel();
            bool flag = true;
            var genders = await shopService.GetAllGenders();
            foreach (var item in genders)
            {
                if (value==item.NameOfGender)
                {
                    model.Products= await shopService.ProductsFilteredByGender(value);
                    model.Advertisments =await shopService.AdsFilteredByGender(value);
                    model.Categories = await shopService.GetAllCategories();
                    model.Genders=genders;
                    flag = false;
                }
            }
            if (flag)
            {
                model.Products =await shopService.ProductsFilteredByCategory(value);
                model.Advertisments =await shopService.AdsFilteredByCategory(value);
                model.Categories = await shopService.GetAllCategories();
                model.Genders = genders;
            }
            return View("~/Views/Shop/Index.cshtml", model);
        }
        
        //[Route("/ProductsFromCategory")]
        //[HttpPost]
        //public async Task<IActionResult> GetProductsFromCategory(string categoryId)
        //{
        //    var id = int.Parse(categoryId);
        //    var products = await shopService.GetAllProducts();
        //    var filtered = products.Where(p => p.CategoryId == id).ToList();

        //    return View()
        //}
    }
}
