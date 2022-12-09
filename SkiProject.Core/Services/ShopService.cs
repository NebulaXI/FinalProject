using Microsoft.EntityFrameworkCore;
using SkiProject.Core.Contracts;
using SkiProject.Infrastructure.Data.Common;
using SkiProject.Infrastructure.Data.Models.Shop;
using System;
using System.Collections.Generic;
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
    }
}
