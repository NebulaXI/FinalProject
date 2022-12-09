using Microsoft.AspNetCore.Mvc.Rendering;
using SkiProject.Infrastructure.Data.Models.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Core.Models
{
    public class AdvertismentsViewModel
    {
        public List<Advertisment> Advertisments { get; set; }
        public List<Product> Products { get; set; }
        public List<SelectListItem> CategoriesSelectList { get; set; }
        public Category Category { get; set; }
        public List<SelectListItem> GendersSelectList { get; set; }
        public List<string> CategoriesNames { get; set; }
        public List<Category> Categories { get; set; }
        public List<Gender> Genders { get; set; }
    }
}
