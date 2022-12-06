using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkiProject.Infrastructure.Data.Models.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Infrastructure.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {

        private List<Category> CreateCategory()
        {
            var categories = new List<Category>();
            var jackets = new Category()
            {
                Id = 1,
                NameOfCategory = "Jackets"
            };
            categories.Add(jackets);
            var pants = new Category()
            {
                Id = 2,
                NameOfCategory = "Pants"
            };
            categories.Add(pants);
            var shoes = new Category()
            {
                Id = 3,
                NameOfCategory = "Shoes"
            };
            categories.Add(shoes);
            var glasses = new Category()
            {
                Id = 4,
                NameOfCategory = "Glasses"
            };
            categories.Add(glasses);
            var helmets = new Category()
            {
                Id = 5,
                NameOfCategory = "Helmets"
            };
            categories.Add(helmets);
            var underwear = new Category()
            {
                Id = 6,
                NameOfCategory = "Underwear"
            };
            categories.Add(underwear);
            var skis = new Category()
            {
                Id = 7,
                NameOfCategory = "Skis"
            };
            categories.Add(skis);
            var snowboards = new Category()
            {
                Id = 8,
                NameOfCategory = "Snowboards"
            };
            categories.Add(snowboards);
            var others = new Category()
            {
                Id = 9,
                NameOfCategory = "Others"
            };
            categories.Add(others);

            return categories;
        }
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CreateCategory());
        }
    }
}
