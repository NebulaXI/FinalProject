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
        Task<City> GetCurrentResort(string name);
        Task<List<PlaceToStay>> GetAllPlacesToStayInCurrentResort(int cityId);
        Task<Slope> GetSlope(int cityId);
    }
}
