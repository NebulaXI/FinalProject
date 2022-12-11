using SkiProject.Core.Contracts;
using SkiProject.Core.Models;
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
    public class MessageService:IMessageService
    {
        private readonly IRepository repo;
        public MessageService(IRepository _repo)
        {
            this.repo = _repo;
        }
        public async Task<ApplicationUser> FindUserByName(string userName)
        {
            var users = repo.All<ApplicationUser>();
            var user = users.FirstOrDefault(u => u.UserName == userName);
            return user;
        }

        public async Task<ApplicationUser> FindUserById(string id)
        {
            var user =await repo.GetByIdAsync<ApplicationUser>(id);
            return user;
        }

        public async Task AddMessageInDB(SendMessageModel model)
        {
            var message = new Message()
            {
                Sender = model.Sender,
                SenderId = model.SenderId,
                Receiver = model.Receiver,
                ReceiverId = model.ReceiverId,
                Content = model.Content
            };
            await repo.AddAsync<Message>(message);
            await repo.SaveChangesAsync();
        }
    }
}
