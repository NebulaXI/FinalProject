using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkiProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Infrastructure.Configuration
{
    public class PlaceToStayConfiguration : IEntityTypeConfiguration<PlaceToStay>
    {

        private List<PlaceToStay> CreatePlaceToStay()
        {
            var placesToStay = new List<PlaceToStay>()
            {
                new PlaceToStay()
                {
                    Id = 1,
                    Name = "Hotel Mura",
                    CityId = 1,
                    Capacity = 300,
                    PricePerNightForAPerson = 150.00M
                },
                new PlaceToStay()
                {
                    Id = 2,
                    Name = "Hotel Saint George",
                    CityId = 1,
                    Capacity = 300,
                    PricePerNightForAPerson = 110.00M
                },
                new PlaceToStay()
                {
                    Id = 3,
                    Name = "Evergreen",
                    CityId = 1,
                    Capacity = 300,
                    PricePerNightForAPerson = 140.00M
                },

                new PlaceToStay()
                {
                    Id = 4,
                    Name = "Hotel Lion",
                    CityId = 2,
                    Capacity = 300,
                    PricePerNightForAPerson = 150.00M
                },
                new PlaceToStay()
                {
                    Id = 5,
                    Name = "Hotel Iglika",
                    CityId = 2,
                    Capacity = 230,
                    PricePerNightForAPerson = 120.00M
                },
                new PlaceToStay()
                {
                    Id = 6,
                    Name = "Hotel Breza",
                    CityId = 2,
                    Capacity = 120,
                    PricePerNightForAPerson = 80.00M
                },

                new PlaceToStay()
                {
                    Id = 7,
                    Name = "Complex Malina",
                    CityId = 3,
                    Capacity = 70,
                    PricePerNightForAPerson = 120.00M
                },
                new PlaceToStay()
                {
                    Id = 8,
                    Name = "Hotel Snezhanka",
                    CityId = 3,
                    Capacity = 230,
                    PricePerNightForAPerson = 160.00M
                },
                new PlaceToStay()
                {
                    Id = 9,
                    Name = "Hotel Perelik",
                    CityId = 3,
                    Capacity = 250,
                    PricePerNightForAPerson = 140.00M
                },

                new PlaceToStay()
                {
                    Id = 10,
                    Name = "Hotel Magnoliya",
                    CityId = 4,
                    Capacity = 40,
                    PricePerNightForAPerson = 30.00M
                },
                new PlaceToStay()
                {
                    Id = 11,
                    Name = "103 Alpine Hotel",
                    CityId = 4,
                    Capacity = 170,
                    PricePerNightForAPerson = 100.00M
                },
                new PlaceToStay()
                {
                    Id =12,
                    Name = "Hotel Panorama",
                    CityId = 4,
                    Capacity = 90,
                    PricePerNightForAPerson = 60.00M
                }
            };
           
            return placesToStay;
        }
        public void Configure(EntityTypeBuilder<PlaceToStay> builder)
        {
            builder.HasData(CreatePlaceToStay());
        }
    }
}
