using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkiProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Infrastructure.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        
        private List<City> CreateCity()
        {
            var cities = new List<City>();
            var bansko = new City()
            {
                Id = 1,
                Name = "Bansko",
                WebCamera= "https://www.banskoski.com/bg/webcams"
            };
            cities.Add(bansko);
            var borovets = new City()
            {
                Id= 2,
                Name = "Borovets",
                WebCamera= "https://weather-webcam.eu/borovec-hotel-ela-online-kamea-rila-na-jivo/"
            };
            cities.Add(borovets);
            var pamporovo = new City()
            {
                Id=3,
                Name = "Pamporovo",
                WebCamera= "http://free-webcambg.com/Pamporovo-07-webcam-live-online-camera-ski-tv-Snejanka-kameri-na-jivo-vremeto-weather.htm"
            };
            cities.Add(pamporovo);
            var panichishte = new City()
            {
                Id=4,
                Name = "Panichishte",
                WebCamera= "http://free-webcambg.com/Rilski-ezera-02-webcam-live-online-camera-hija-Pionerska-Panichishte-Rila-kameri-na-jivo-vremeto-weather.htm"
            };
            cities.Add(panichishte);

            return cities;
        }
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(CreateCity());
        }
    }
}
