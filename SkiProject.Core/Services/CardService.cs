using SkiProject.Core.Contracts;
using SkiProject.Infrastructure.Data.Common;
using SkiProject.Infrastructure.Data.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Core.Services
{
    public class CardService : ICardService
    {
        private readonly IRepository repo;

        public CardService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task UpdateCardInfo()
        {
            await repo.SaveChangesAsync();
        }
        
    }
}
