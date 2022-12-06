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
    public class AdvertismentConfiguration : IEntityTypeConfiguration<Advertisment>
    {
        private List<Advertisment> CreateAdvertisments()
        {
            var advertisments = new List<Advertisment>();
            var ad1 = new Advertisment()
            {
                Id = 1,
                ProductId = 1,
                Title = "Woman jacket",
                UserId = "d33b5866-1720-4e84-bfba-977e3a864f86",
                CreatedOn = DateTime.Now,
                LastUpdatedOn = DateTime.Now
            };
            advertisments.Add(ad1);
            var ad2 = new Advertisment()
            {
                Id = 2,
                ProductId = 2,
                Title = "Men pants",
                UserId = "d33b5866-1720-4e84-bfba-977e3a864f86",
                CreatedOn = DateTime.Now,
                LastUpdatedOn = DateTime.Now
            };
            advertisments.Add(ad2);
            return advertisments;
        }
        public void Configure(EntityTypeBuilder<Advertisment> builder)
        {
            builder.HasData(CreateAdvertisments());
        }
    }
}
