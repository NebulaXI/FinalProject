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
    }
}
