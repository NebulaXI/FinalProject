using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
using System.Net.WebSockets;
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

        

        /// <summary>
        /// Returns all advertisments
        /// </summary>
        /// <returns></returns>
        public async Task<List<Advertisment>> GetAllAdvertisments()
        {
            var advertisments = await repo.All<Advertisment>().ToListAsync();
            return advertisments;
        }

        /// <summary>
        /// Returns all products
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> GetAllProducts()
        {
            var products = await repo.All<Product>().ToListAsync();
            return products;
        }

        /// <summary>
        /// Returns all categories
        /// </summary>
        /// <returns></returns>
        public async Task<List<Category>> GetAllCategories()
        {
            var categories = await repo.All<Category>().ToListAsync();
            return categories;
        }

        /// <summary>
        /// Returns all genders
        /// </summary>
        /// <returns></returns>
        public async Task<List<Gender>> GetAllGenders()
        {
            var genders = await repo.All<Gender>().ToListAsync();
            return genders;
        }

        /// <summary>
        /// Returns all products which are filtered by gender
        /// </summary>
        /// <param name="nameOfGender"></param>
        /// <returns></returns>
        public async Task<List<Product>> ProductsFilteredByGender(string nameOfGender)
        {
            var genders = await GetAllGenders();
            var gender = genders.First(c => c.NameOfGender == nameOfGender);
            var id = gender.Id;
            var products = await GetAllProducts();
            var filteredProducts = products.Where(p => p.GenderId == id).ToList();
            return filteredProducts;
        }

        /// <summary>
        /// Returns all products which are filtered by category
        /// </summary>
        /// <param name="nameOfCategory"></param>
        /// <returns></returns>
        public async Task<List<Product>> ProductsFilteredByCategory(string nameOfCategory)
        {
            var categories = await GetAllCategories();
            var categorie = categories.First(c => c.NameOfCategory == nameOfCategory);
            var id = categorie.Id;
            var products = await GetAllProducts();
            var filteredProducts = products.Where(p => p.CategoryId == id).ToList();
            return filteredProducts;
        }
        /// <summary>
        /// Returns all advertisments which are filtered by category
        /// </summary>
        /// <param name="nameOfCategory"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns all advertisments which are filtered by gender
        /// </summary>
        /// <param name="nameOfGender"></param>
        /// <returns></returns>

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


        /// <summary>
        /// Gets the category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Category> GetCategoryById(int id)
        {
            var categories = await GetAllCategories();
            var category = categories.FirstOrDefault(c => c.Id == id);
            return category;
        }


        /// <summary>
        /// Gets gender by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Creates new product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates new advertisment
        /// </summary>
        /// <param name="model"></param>
        /// <param name="product"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Adds new product to the database
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task AddNewProduct(Product product)
        {
            await repo.AddAsync(product);
            await repo.SaveChangesAsync();

        }

        /// <summary>
        /// Adds new advertisment to the database
        /// </summary>
        /// <param name="advertisment"></param>
        /// <returns></returns>
        public async Task AddNewAdvetisment(Advertisment advertisment)
        {
            await repo.AddAsync(advertisment);
            await repo.SaveChangesAsync();
        }


        /// <summary>
        /// Gets the last added product by user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Product> GetLastProductByUserId(string userId)
        {
            var products = repo.All<Product>().Where(u => u.CreatedByUserId == userId);
            var lastProduct = products.Last();
            return lastProduct;
        }

        /// <summary>
        /// Gets advertisment by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<Advertisment> GetAdvertismentById(int id)
        {
            var ads = await GetAllAdvertisments();
            var ad = ads.FirstOrDefault(g => g.Id == id);
            return ad;
        }


        /// <summary>
        /// Gets product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Product> GetProductById(int id)
        {
            var products = await GetAllProducts();
            var product = products.FirstOrDefault(p => p.Id == id);
            return product;
        }
        /// <summary>
        /// Returns a collection of byte arrays of all images,which have the same product id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<byte[]>> GetImagesData(int productId)
        {
            
            var images = await GetImagesByProductId(productId);
            var imagesData = new List<byte[]>();
            foreach (var image in images)
            {
                imagesData.Add(image.ImageData);
            }
            return imagesData;
        }
        /// <summary>
        /// Returns byte array of a particular image by image id
        /// </summary>
        /// <param name="imageId"></param>
        /// <returns></returns>
        public async Task<byte[]> GetImageData(int imageId)
        {
            var image = await repo.GetByIdAsync<ProductImage>(imageId);
            
            return image.ImageData;
        }
        /// <summary>
        /// Returns a collection of ProductImage,which have the same product id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductImage>> GetImagesByProductId(int productId)
        {
            var images = repo.All<ProductImage>().Where(p => p.ProductId == productId);
            images.ToList();
            return images;
        }

        /// <summary>
        /// Remove an Advertisment by it's id
        /// </summary>
        /// <param name="adId"></param>
        /// <returns></returns>
        public async Task DeleteAdvertisment(int adId)
        {
            var ad = await GetAdvertismentById(adId);
            repo.Delete(ad);
            await repo.SaveChangesAsync();
        }
    }
}
