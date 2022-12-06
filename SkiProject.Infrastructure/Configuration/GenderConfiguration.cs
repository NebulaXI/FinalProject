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
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        private List<Gender> CreateGenders()
        {
            var genders = new List<Gender>();
            var kids = new Gender()
            {
                Id = 1,
                NameOfGender = "Kids"
            };
            genders.Add(kids);
            var women = new Gender()
            {
                Id = 2,
                NameOfGender = "Women"
            };
            genders.Add(women);
            var men = new Gender()
            {
                Id = 3,
                NameOfGender = "Men"
            };
            genders.Add(men);
            var unisex = new Gender()
            {
                Id = 4,
                NameOfGender = "Unisex"
            };
            genders.Add(unisex);
            return genders;
        }
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasData(CreateGenders());
        }
    }
}
