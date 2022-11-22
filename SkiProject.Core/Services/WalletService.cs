using SkiProject.Core.Contracts;
using SkiProject.Infrastructure.Data;
using SkiProject.Infrastructure.Data.Common;
using SkiProject.Infrastructure.Data.Models.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Core.Services
{
    public class WalletService : IWalletService
    {
        private readonly IRepository repo;

        public WalletService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task Add(Wallet currentWallet,decimal amount)
        {
            currentWallet.AmountInWallet += amount;
            await repo.SaveChangesAsync();
        }

        //Creates an empty wallet
        public async Task Create(string userId)
        {
            var wallet = new Wallet()
            {
                UserId = userId,
                AmountInWallet=0M
            };

            await repo.AddAsync(wallet);
            await repo.SaveChangesAsync();
        }

       public async Task<Wallet> GetCurrentWallet(string userId)
        {
            var wallet = await repo.All<Wallet>().FirstOrDefaultAsync(a=>a.UserId == userId);
            return wallet;
        }

        public decimal GetAmountInWallet(Wallet wallet)
        {
            return  wallet.AmountInWallet;
        }


        public async Task<bool> ExistById(string id)
        {
            return await repo.All<Wallet>()
                .AnyAsync(a => a.UserId == id);
        }

    }
}
