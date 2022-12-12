﻿using Microsoft.AspNetCore.Mvc.Rendering;
using SkiProject.Core.Models;
using SkiProject.Infrastructure.Data.Models.Account;
using SkiProject.Infrastructure.Data.Models.Shop;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Core.Contracts
{
    public interface IShopService
    {
        /// <summary>
        /// Returns all advertisments
        /// </summary>
        /// <returns></returns>
        Task<List<Advertisment>> GetAllAdvertisments();

        /// <summary>
        /// Returns all products
        /// </summary>
        /// <returns></returns>
        Task<List<Product>> GetAllProducts();

        /// <summary>
        /// Returns all categories
        /// </summary>
        /// <returns></returns>
        Task<List<Category>> GetAllCategories();

        /// <summary>
        /// Returns all genders
        /// </summary>
        /// <returns></returns>
        Task<List<Gender>> GetAllGenders();

        /// <summary>
        /// Returns all advertisments which are filtered by category
        /// </summary>
        /// <param name="nameOfCategory"></param>
        /// <returns></returns>
        Task<List<Advertisment>> AdsFilteredByCategory(string nameOfCategory);

        /// <summary>
        /// Returns all advertisments which are filtered by gender
        /// </summary>
        /// <param name="nameOfGender"></param>
        /// <returns></returns>
        Task<List<Advertisment>> AdsFilteredByGender(string nameOfGender);

        /// <summary>
        /// Returns all products which are filtered by gender
        /// </summary>
        /// <param name="nameOfGender"></param>
        /// <returns></returns>
        Task<List<Product>> ProductsFilteredByGender(string nameOfGender);
        /// <summary>
        /// Returns all products which are filtered by category
        /// </summary>
        /// <param name="nameOfCategory"></param>
        /// <returns></returns>
        Task<List<Product>> ProductsFilteredByCategory(string nameOfCategory);

        /// <summary>
        /// Gets the category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Category> GetCategoryById(int id);

        /// <summary>
        /// Gets gender by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Gender> GetGenderById(int id);
        Task<List<SelectListItem>> CreateSelectListItemCategory();
        Task<List<SelectListItem>> CreateSelectListItemGender();

        /// <summary>
        /// Creates new product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Product> CreateProduct(NewProductViewModel model);

        /// <summary>
        /// Adds new product to the database
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task AddNewProduct(Product product);

        /// <summary>
        /// Gets the last added product by user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<Product> GetLastProductByUserId(string userId);

        /// <summary>
        /// Gets user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApplicationUser> GetCurrentUser(string id);

        /// <summary>
        /// Creates new advertisment
        /// </summary>
        /// <param name="model"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<Advertisment> CreateAdvertisment(NewProductViewModel model,Product product);

        /// <summary>
        /// Adds new advertisment to the database
        /// </summary>
        /// <param name="advertisment"></param>
        /// <returns></returns>
        Task AddNewAdvetisment(Advertisment advertisment);

        /// <summary>
        /// Gets advertisment by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Advertisment> GetAdvertismentById(int id);

        /// <summary>
        /// Gets product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product> GetProductById(int id);
        Task<IEnumerable<byte[]>> GetImageData(int productId);
        Task<Image> byteArrayToImage(byte[] bytesArr);
        Task<List<string>> GenerateImageUrls(List<Image> images);
    }
}
