using SkiProject.Infrastructure.Data.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Core.Contracts
{
    public interface IAccountService
    {
        //Gets the current user by id
        Task<ApplicationUser> GetCurrentUserById(string userId);

        //Gets the current user by username
        Task<ApplicationUser> GetCurrentUserByUsername(string username);
        //Updates the logged in user data in the database
        Task UpdateUser();
    }
}
