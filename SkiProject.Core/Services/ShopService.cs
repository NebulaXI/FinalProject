using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using SkiProject.Core.Contracts;
using SkiProject.Core.Models;
using SkiProject.Infrastructure.Data.Common;
using SkiProject.Infrastructure.Data.Models.Account;
using SkiProject.Infrastructure.Data.Models.Shop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Core.Services
{
    public class ShopService : IShopService
    {
        private readonly IRepository repo;
        public ShopService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public async Task<ApplicationUser> GetCurrentUser(string id)
        {
            var user = repo.All<ApplicationUser>().FirstOrDefault(o => o.Id == id);
            return user;
        }
        public async Task<List<Advertisment>> GetAllAdvertisments()
        {
            var advertisments = await repo.All<Advertisment>().ToListAsync();
            return advertisments;
        }
        public async Task<List<Product>> GetAllProducts()
        {
            var products = await repo.All<Product>().ToListAsync();
            return products;
        }
        public async Task<List<Category>> GetAllCategories()
        {
            var categories = await repo.All<Category>().ToListAsync();
            return categories;
        }
        public async Task<List<Gender>> GetAllGenders()
        {
            var genders = await repo.All<Gender>().ToListAsync();
            return genders;
        }
        public async Task<List<Product>> ProductsFilteredByGender(string nameOfGender)
        {
            var genders = await GetAllGenders();
            var gender = genders.First(c => c.NameOfGender == nameOfGender);
            var id = gender.Id;
            var products = await GetAllProducts();
            var filteredProducts = products.Where(p => p.GenderId == id).ToList();
            return filteredProducts;
        }
        public async Task<List<Product>> ProductsFilteredByCategory(string nameOfCategory)
        {
            var categories = await GetAllCategories();
            var categorie = categories.First(c => c.NameOfCategory == nameOfCategory);
            var id = categorie.Id;
            var products = await GetAllProducts();
            var filteredProducts = products.Where(p => p.CategoryId == id).ToList();
            return filteredProducts;
        }
        public async Task<List<Advertisment>> AdsFilteredByCategory(string nameOfCategory)
        {
            var filteredProducts = await ProductsFilteredByCategory(nameOfCategory);
            var advertisments = await GetAllAdvertisments();
            var filteredAdvertisments = new List<Advertisment>();
            foreach (var prod in filteredProducts)
            {
                foreach (var ad in advertisments)
                {
                    if (prod.Id == ad.ProductId)
                    {
                        filteredAdvertisments.Add(ad);
                    }
                }
            }

            return filteredAdvertisments;
        }

        public async Task<List<Advertisment>> AdsFilteredByGender(string nameOfGender)
        {
            var filteredProducts = await ProductsFilteredByGender(nameOfGender);
            var advertisments = await GetAllAdvertisments();
            var filteredAdvertisments = new List<Advertisment>();
            foreach (var prod in filteredProducts)
            {
                foreach (var ad in advertisments)
                {
                    if (prod.Id == ad.ProductId)
                    {
                        filteredAdvertisments.Add(ad);
                    }
                }
            }

            return filteredAdvertisments;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var categories = await GetAllCategories();
            var category = categories.FirstOrDefault(c => c.Id == id);
            return category;
        }

        public async Task<Gender> GetGenderById(int id)
        {
            var genders = await GetAllGenders();
            var gender = genders.FirstOrDefault(g => g.Id == id);
            return gender;
        }

        public async Task<List<SelectListItem>> CreateSelectListItemCategory()
        {
            var cat = await GetAllCategories();
            var categories = new List<SelectListItem>();
            foreach (var item in cat)
            {
                categories.Add(new SelectListItem
                {
                    Text = item.NameOfCategory,
                    Value = item.Id.ToString(),
                });
            }
            return categories;
        }
        public async Task<List<SelectListItem>> CreateSelectListItemGender()
        {
            var gen = await GetAllGenders();
            var genders = new List<SelectListItem>();
            foreach (var item in gen)
            {
                genders.Add(new SelectListItem
                {
                    Text = item.NameOfGender,
                    Value = item.Id.ToString()
                });
            }
            return genders;
        }

        public async Task<Product> CreateProduct(NewProductViewModel model)
        {
            var product = new Product()
            {
                CategoryId = model.CategoryId,
                Category = model.Category,
                GenderId = model.GenderId,
                Gender = model.Gender,
                Price = model.Price,
                Description = model.Description,
                ProductImages = model.ProductImages,
                CreatedByUserId = model.CreatedByUserId,
                User = model.User
            };
            return product;
        }
        public async Task<Advertisment> CreateAdvertisment(NewProductViewModel model, Product product)
        {

            var advertisment = new Advertisment()
            {
                Product = product,
                ProductId = product.Id,
                User = model.User,
                UserId = model.CreatedByUserId,
                CreatedOn = model.CreatedOn,
                LastUpdatedOn = model.LastUpdatedOn,
                Image = product.ProductImages.Select(i => i.ImageData).FirstOrDefault(),
                Title = model.Title
            };
            return advertisment;
        }
        public async Task AddNewProduct(Product product)
        {
            await repo.AddAsync(product);
            await repo.SaveChangesAsync();

        }
        public async Task AddNewAdvetisment(Advertisment advertisment)
        {
            await repo.AddAsync(advertisment);
            await repo.SaveChangesAsync();
        }

        public async Task<Product> GetLastProductByUserId(string userId)
        {
            var products = repo.All<Product>().Where(u => u.CreatedByUserId == userId);
            var lastProduct = products.Last();
            return lastProduct;
        }

        public async Task<Advertisment> GetAdvertismentById(int id)
        {
            var ads = await GetAllAdvertisments();
            var ad = ads.FirstOrDefault(g => g.Id == id);
            return ad;
        }

        public async Task<Product> GetProductById(int id)
        {
            var products = await GetAllProducts();
            var product = products.FirstOrDefault(p => p.Id == id);
            return product;
        }

        public async Task<IEnumerable<byte[]>> GetImageData(int productId)
        {
            var images = repo.All<ProductImage>().Where(p => p.ProductId == productId);
            var imagesData = new List<byte[]>();
            foreach (var image in images)
            {
                imagesData.Add(image.ImageData);
            }
            return imagesData;
        }
        public async Task<Image> byteArrayToImage(byte[] bytesArr)
        {
            string folderPath = ("~/Images/"); 
            string fileName = "Image.jpg";
            string imagePath = folderPath + fileName;
            using (MemoryStream memstr = new MemoryStream(bytesArr))
            {
                Image img = Image.FromStream(memstr);
                //img.Save(imagePath, ImageFormat.Jpeg);
                return img;
            }

        }
        public async Task<List<string>> GenerateImageUrls(List<Image> images)
        {
            var urls = new List<string>();
            int n = 1;
            foreach (var img in images)
            {
                if (Directory.GetFiles(@"Images/Ads").Length == 0)
                {
                    img.Save($"/Images/Ads/image{n}", ImageFormat.Jpeg);
                    n++;
                    urls.Add($"/Images/Ads/image{n}");
                }
                //else
                //{
                //    var files = Directory.GetFiles(@"Images/Ads");
                //    foreach (var file in files)
                //    {
                //        file.Replace()
                //    }
                //}
                
            }
            return urls;
        }
    }
}
