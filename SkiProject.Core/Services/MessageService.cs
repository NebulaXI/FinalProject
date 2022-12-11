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

        public async Task<Message> AddMessageInDB(SendMessageModel model)
        {
            var message = new Message()
            {
                Sender = model.Sender,
                SenderId = model.SenderId,
                Receiver = model.Receiver,
                ReceiverId = model.ReceiverId,
                Content = model.Content,
                CreatedOn = DateTime.Now
            };
            await repo.AddAsync<Message>(message);
            await repo.SaveChangesAsync();
            return message;
        }
        public async Task AddMessageToReceived(ApplicationUser receiver,Message message)
        {
            if (receiver.ReceivedMessages == null)
            {
                var receivedMes = new List<Message>();
                receivedMes.Add(message);
            }
            else
            {
                var receivedMes = receiver.ReceivedMessages;
                receivedMes.Add(message);
            }

            await repo.SaveChangesAsync();
        }

        public async Task AddMessageToSent (ApplicationUser sender,Message message)
        {
           
            if (sender.SentMessages==null)
            {
                var sentMes = new List<Message>();
                sentMes.Add(message);
            }
            else
            {
                var sentMes = sender.SentMessages;
                sentMes.Add(message);
            }
            
            await repo.SaveChangesAsync();
        }
    }
}
