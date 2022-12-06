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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        private List<Product> CreateProducts()
        {
            var products = new List<Product>();
            var product1 = new Product()
            {
                Id = 1,
                CategoryId = 1,
                GenderId = 2,
                Price = 120.0M,
                Description = "Woman jacket"
            };
            products.Add(product1);
            var product2 = new Product()
            {
                Id = 2,
                CategoryId = 2,
                GenderId = 3,
                Price = 80.0M,
                Description = "Men pants"
            };
            products.Add(product2);
            return products;
        }
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(CreateProducts());
        }
    }
}
