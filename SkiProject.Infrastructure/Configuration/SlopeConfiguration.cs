using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkiProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiProject.Infrastructure.Data.Common;
using SkiProject.Infrastructure.Data;

namespace SkiProject.Infrastructure.Configuration
{
    public class SlopeConfiguration : IEntityTypeConfiguration<Slope>
    {
     
        private List<Slope> CreateSlope()
        {
            var slopes = new List<Slope>();
            var banskoSlope = new Slope()
            {
                Id = 1,
                CityId = 1,
                PricePerDayChildren = 25.00M,
                PricePerDayAdult = 80.00M,
                PriceForSeasonChildren = 350.00M,
                PriceForSeasonAdult = 1500.00M
            };
            slopes.Add(banskoSlope);
            var borovetsSlope = new Slope()
            {
                Id = 2,
                CityId = 2,
                PricePerDayChildren = 20.00M,
                PricePerDayAdult = 76.00M,
                PriceForSeasonChildren = 310.00M,
                PriceForSeasonAdult = 1200.00M
            };
            slopes.Add(borovetsSlope);
            var pamporovoSlope = new Slope()
            {
                Id = 3,
                CityId = 3,
                PricePerDayChildren = 20.00M,
                PricePerDayAdult = 80.00M,
                PriceForSeasonChildren = 340.00M,
                PriceForSeasonAdult = 1410.00M
            };
            slopes.Add(pamporovoSlope);
            var panichishteSlope = new Slope()
            {
                Id = 4,
                CityId = 4,
                PricePerDayChildren = 15.00M,
                PricePerDayAdult = 32.00M,
                PriceForSeasonChildren = 120.00M,
                PriceForSeasonAdult = 500.00M
            };
            slopes.Add(panichishteSlope);
            return slopes;
        }
        public void Configure(EntityTypeBuilder<Slope> builder)
        {
            builder.HasData(CreateSlope());
        }
    }
}
