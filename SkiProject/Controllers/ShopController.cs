using Microsoft.AspNetCore.Mvc;
using SkiProject.Core.Contracts;
using SkiProject.Core.Models;
using SkiProject.Infrastructure.Data.Models.Shop;

namespace SkiProject.Controllers
{
    [Route("/Shop")]
    public class ShopController : BaseController
    {

        private readonly IShopService shopService;
        public ShopController(IShopService _shopService)
        {
            this.shopService = _shopService;
        }
        public async Task<IActionResult> Index()
        {
            var advretisments = await shopService.GetAllAdvertisments();
            var products = await shopService.GetAllProducts();
            var categories = await shopService.GetAllCategories();
            var genders = await shopService.GetAllGenders();
            var model = new AdvertismentsViewModel() { Advertisments = advretisments,Products=products,Categories=categories,Genders=genders };
            return View(model);
        }

        //[Route("/ProductsFromCategory")]
        //public IActionResult GetProductsFromCategory(int categoryId)
        //{
        //    var products = await shopService.GetAllProducts();
        //    var filtered = products.Where(p => p.CategoryId == categoryId).ToList();

        //    return Ok{ new {text="OK"}};
        //}
    }
}
