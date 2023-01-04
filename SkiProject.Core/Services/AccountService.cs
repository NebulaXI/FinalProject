using SkiProject.Core.Contracts;
using SkiProject.Infrastructure.Data.Common;
using SkiProject.Infrastructure.Data.Models.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository repo;

        public AccountService(IRepository _repo)
        {
            repo = _repo;
        }

        /// <summary>
        /// Gets the current user by Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> GetCurrentUserById(string userId)
        {
            var currentUser = await repo.GetByIdAsync<ApplicationUser>(userId);
            return currentUser;
        }

        public async Task<ApplicationUser> GetCurrentUserByUsername(string username)
        {
            var users = repo.All<ApplicationUser>();
            var user = users.FirstOrDefault(u => u.UserName == username);
            return user;
        }
        /// <summary>
        /// Updates the logged in user data in the database
        /// </summary>
        /// <returns></returns>
        public async Task UpdateUser ()
        {
            await repo.SaveChangesAsync();
        }
    }
}
