using SkiProject.Infrastructure.Data.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Core.Contracts
{
    public interface IWalletService
    {
        Task<bool> ExistById(string id);
        Task Create(string id);
        Task Add(Wallet currentWallet,decimal amount);
        Task<Wallet> GetCurrentWallet(string id);
        decimal GetAmountInWallet(Wallet wallet);
    }
}
