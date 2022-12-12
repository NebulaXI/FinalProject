using SkiProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Core.Contracts
{
    public interface IResortService
    {
        /// <summary>
        /// Gets resort by it's name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<City> GetCurrentResort(string name);

        /// <summary>
        /// Gets all places to stay in the current resort by cityId
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        Task<List<PlaceToStay>> GetAllPlacesToStayInCurrentResort(int cityId);

        /// <summary>
        /// Gets all slopes in the current resort by cityId
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        Task<Slope> GetSlope(int cityId);
    }
}
