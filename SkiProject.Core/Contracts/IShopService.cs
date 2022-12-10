using Microsoft.AspNetCore.Mvc.Rendering;
using SkiProject.Core.Models;
using SkiProject.Infrastructure.Data.Models.Account;
using SkiProject.Infrastructure.Data.Models.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Core.Contracts
{
    public interface IShopService
    {
        Task<List<Advertisment>> GetAllAdvertisments();
        Task<List<Product>> GetAllProducts();
        Task<List<Category>> GetAllCategories();
        Task<List<Gender>> GetAllGenders();
        Task<List<Advertisment>> AdsFilteredByCategory(string nameOfCategory);
        Task<List<Advertisment>> AdsFilteredByGender(string nameOfGender);
        Task<List<Product>> ProductsFilteredByGender(string nameOfGender);
        Task<List<Product>> ProductsFilteredByCategory(string nameOfCategory);
        Task<Category> GetCategoryById(int id);
        Task<Gender> GetGenderById(int id);
        Task<List<SelectListItem>> CreateSelectListItemCategory();
        Task<List<SelectListItem>> CreateSelectListItemGender();
        Task<Product> CreateProduct(NewProductViewModel model);
        Task AddNewProduct(Product product);
        Task<Product> GetLastProductByUserId(string userId);
        Task<ApplicationUser> GetCurrentUser(string id);
        Task<Advertisment> CreateAdvertisment(NewProductViewModel model,Product product);
        Task AddNewAdvetisment(Advertisment advertisment);
        Task<Advertisment> GetAdvertismentById(int id);
        Task<Product> GetProductById(int id);
    }
}
