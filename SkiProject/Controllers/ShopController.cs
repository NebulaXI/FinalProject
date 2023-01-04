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
        private readonly IAccountService accountService;
        public ShopController(IShopService _shopService,IAccountService _accountService)
        {
            this.shopService = _shopService;
            this.accountService = _accountService;
        }
        public async Task<IActionResult> Index()
        {
            var model = new AdvertismentsViewModel();
            var advretisments = await shopService.GetAllAdvertisments();
            var products = await shopService.GetAllProducts();
            var categories = await shopService.GetAllCategories();
            var genders = await shopService.GetAllGenders();
            if (advretisments.Count==0)
            {
                return View("NoAds");
            }
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
            var productImages = new List<ProductImage>();
            if (Request.Form.Files.Count<5)
            {
                foreach (var file in Request.Form.Files)
                {
                    var img = new ProductImage();
                    img.ImageName = Guid.NewGuid().ToString();

                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);
                    img.ImageData = ms.ToArray();
                    
                    ms.Close();
                    ms.Dispose();

                    productImages.Add(img);
                }
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
                ProductImages =productImages,
                CreatedByUserId=userId,
                Title=sanitizer.Sanitize(DTOModel.Title),
                User=await accountService.GetCurrentUserById(userId),
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
            TempData["currentUserId"]= User.FindFirstValue(ClaimTypes.NameIdentifier);
            var ad = await shopService.GetAdvertismentById(AdvertismentId);
            var product = await shopService.GetProductById(ad.ProductId);
            var imagesData = await shopService.GetImagesData(ad.ProductId);
            var ownerId = ad.UserId;
            var owner = await accountService.GetCurrentUserById(ownerId);
            var ownerUserName = owner.UserName;
            HttpContext.Response.Cookies.Append("visited_ad_owner", ownerUserName);
           
            var model = new ShowAdvertismentViewModel()
            {
                CategoryId = product.CategoryId,
                Category = product.Category,
                GenderId = product.GenderId,
                Gender = product.Gender,
                Price = product.Price,
                Description = product.Description,
                CreatedByUserId = ownerId,
                Title = ad.Title,
                User = owner,
                CreatedOn = ad.CreatedOn,
                LastUpdatedOn = ad.LastUpdatedOn,
                AdvertismentId=AdvertismentId,
                ImageArrays=imagesData
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAdvertisment(string createdByUserId,int adId)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (currentUserId==createdByUserId)
            {
                await shopService.DeleteAdvertisment(adId);
            }
            return RedirectToAction("Index");
        }
        
    }
}
