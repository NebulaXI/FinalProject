using SkiProject.Core.Services;
using SkiProject.Infrastructure.Data.Common;
using SkiProject.Infrastructure.Data.Models;
using SkiProject.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SkiProject.Test.Services
{
    public  class ResortServiceTest
    {

        [Fact]
        public async Task GetCurrentResortShouldReturnCurrentResort()
        {
            var data = DBMock.Instance;
            var repo = new Repository(data);
            var resortService = new ResortService(repo);
            var city = new City()
            {
                Id = 1,
                Name = "Bansko",
                WebCamera = "https://www.banskoski.com/bg/webcams"
            };
            data.Cities.Add(city);
            var borovets = new City()
            {
                Id = 2,
                Name = "Borovets",
                WebCamera = "https://weather-webcam.eu/borovec-hotel-ela-online-kamea-rila-na-jivo/"
            };
            data.Cities.Add(borovets);
            await data.SaveChangesAsync();

            var result = await resortService.GetCurrentResort(city.Name);

            Assert.Equal(city.Name, result.Name);
            Assert.Equal(city.Id,result.Id);
            Assert.Equal(city.WebCamera, result.WebCamera);
        }

        [Fact]
        public async Task GetAllPlacesToStayShouldReturnListOfPlacesToStay()
        {
            var data = DBMock.Instance;
            var repo = new Repository(data);
            var resortService = new ResortService(repo);
            var city = new City()
            {
                Id = 1,
                Name = "Bansko",
                WebCamera = "https://www.banskoski.com/bg/webcams",
                PlacesToStay=new List<PlaceToStay>()
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
                     }
                }
            };
            data.Cities.Add(city);
            await data.SaveChangesAsync();

            var result = await resortService.GetAllPlacesToStayInCurrentResort(city.Id);

            Assert.NotNull(result);
            Assert.Equal(city.PlacesToStay.Count(), result.Count);
        }

        [Fact]
        public async Task GetSlopeShouldReturnCorrectSlope()
        {
            var data = DBMock.Instance;
            var repo = new Repository(data);
            var resortService = new ResortService(repo);
            var city = new City()
            {
                Id = 1,
                Name = "Bansko",
                WebCamera = "https://www.banskoski.com/bg/webcams",
                Slope = new Slope()
                {
                    Id = 1,
                    CityId = 1,
                    PricePerDayChildren = 25.00M,
                    PricePerDayAdult = 80.00M,
                    PriceForSeasonChildren = 350.00M,
                    PriceForSeasonAdult = 1500.00M
                }
            };
            data.Cities.Add(city);
            await data.SaveChangesAsync();

            var result = await resortService.GetSlope(city.Id);

            Assert.NotNull(result);
            Assert.Equal(city.Slope, result);
        }
    }
}
