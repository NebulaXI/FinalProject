using Microsoft.EntityFrameworkCore;
using SkiProject.Core.Contracts;
using SkiProject.Infrastructure.Data.Common;
using SkiProject.Infrastructure.Data.Models;
using SkiProject.Infrastructure.Data.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Core.Services
{
    public class ResortService:IResortService
    {
        private readonly IRepository repo;

        public ResortService(IRepository _repo)
        {
            repo = _repo;
        }

        /// <summary>
        /// Gets resort by it's name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<City> GetCurrentResort(string name)
        {
            var city = await repo.All<City>().FirstOrDefaultAsync(a => a.Name == name);
            return city;
        }

        /// <summary>
        /// Gets all places to stay in the current resort by cityId
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public async Task<List<PlaceToStay>> GetAllPlacesToStayInCurrentResort(int cityId)
        {
            var placesInCity = await repo.All<PlaceToStay>().Where(a => a.CityId == cityId).ToListAsync();
            return placesInCity;
        }


        /// <summary>
        /// Gets all slopes in the current resort by cityId
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public async Task<Slope> GetSlope(int cityId)
        {
            var slope = await repo.All<Slope>().FirstOrDefaultAsync(a => a.CityId == cityId);
            return slope;
        }

    }
}
