using Ganss.Xss;
using Microsoft.AspNetCore.Mvc;
using SkiProject.Core.Contracts;
using SkiProject.Core.Models;
using SkiProject.Infrastructure.Data.Models.Shop;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.StaticFiles.Infrastructure;
using System.Reflection;
using SkiProject.Core.Services;
using System.Drawing;

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
            var categories = await shopService.CreateSelectListItemCategory();
            var genders = await shopService.CreateSelectListItemGender();
            var model = new NewProductViewModel() { Categories=categories,Genders=genders};
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewProduct(NewProductViewModel DTOModel)
        {
            var sanitizer = new HtmlSanitizer();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var sanitizedPrice = sanitizer.Sanitize(DTOModel.Price.ToString());
            var category = await shopService.GetCategoryById(int.Parse(DTOModel.SelectedCategory));
            var gender = await shopService.GetGenderById(int.Parse(DTOModel.SelectedGender));
            var images = new List<ProductImage>();
            foreach (var file in Request.Form.Files)
            {
                var img = new ProductImage();
                img.ImageName = file.FileName;

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                img.ImageData = ms.ToArray();

                ms.Close();
                ms.Dispose();

                images.Add(img);
            }
            var model = new NewProductViewModel()
            {
                CategoryId =int.Parse(DTOModel.SelectedCategory),
                Category = category,
                Categories = await shopService.CreateSelectListItemCategory(),
                SelectedCategory =DTOModel.SelectedCategory,
                SelectedCategoryText=category.NameOfCategory,
                GenderId =int.Parse(DTOModel.SelectedGender),
                Gender = gender,
                Genders=await shopService.CreateSelectListItemGender(),
                SelectedGender=DTOModel.SelectedGender,
                SelectedGenderText= gender.NameOfGender,
                Price =Decimal.Parse(sanitizedPrice),
                Description =sanitizer.Sanitize(DTOModel.Description),
                ProductImages =images,
                CreatedByUserId=userId,
                Title=sanitizer.Sanitize(DTOModel.Title),
                User=await shopService.GetCurrentUser(userId),
                CreatedOn=DateTime.Now,
                LastUpdatedOn=DateTime.Now
            };
            foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors)) { int a =5; }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var product = await shopService.CreateProduct(model);
            var advertisment = await shopService.CreateAdvertisment(model,product);
            await shopService.AddNewProduct(product);
            await shopService.AddNewAdvetisment(advertisment);
            return RedirectToAction("Index","Shop");
        }

        public async Task<IActionResult> ShowAdvertisment(int AdvertismentId)
        {
            var ad = await shopService.GetAdvertismentById(AdvertismentId);
            var product = await shopService.GetProductById(ad.ProductId);
            var imagesData = await shopService.GetImageData(ad.ProductId);
            var images = new List<Image>();
            var imagesUrl = await GenerateImageUrls()
            foreach (var item in imagesData)
            {
                images.Add(await shopService.byteArrayToImage(item));
            }
            
            var model = new ShowAdvertismentViewModel()
            {
                CategoryId = product.CategoryId,
                Category = product.Category,
                GenderId = product.GenderId,
                Gender = product.Gender,
                Price = product.Price,
                Description = product.Description,
                CreatedByUserId = product.CreatedByUserId,
                Title = ad.Title,
                User = ad.User,
                CreatedOn = ad.CreatedOn,
                LastUpdatedOn = ad.LastUpdatedOn,
                ImagesData= imagesData,
                Images=images,
                ImagesUrl
            };

            return View(model);
        }


        
    }
}
