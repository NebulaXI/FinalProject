using SkiProject.Core.Contracts;
using SkiProject.Core.Models;
using SkiProject.Infrastructure.Data.Common;
using SkiProject.Infrastructure.Data.Models;
using SkiProject.Infrastructure.Data.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                SenderId = model.SenderId,
                Receiver = model.Receiver,
                ReceiverId = model.ReceiverId,
                Content = model.Content,
                CreatedOn = DateTime.Now
            };
            await repo.AddAsync(message);
            //await AddMessageToUser(model.Receiver, message);
            //await AddMessageToUser(model.Sender,message);
            await repo.SaveChangesAsync();
            return message;
        }
        public async Task AddMessageToUser(ApplicationUser user,Message message)
        {
            if (user.Messages == null)
            {
                var receivedMes = new List<Message>();
                receivedMes.Add(message);
            }
            else
            {
                var receivedMes = user.Messages;
                receivedMes.Add(message);
            }

            await repo.SaveChangesAsync();
        }



        public async Task<List<Message>> GetAllMessages(ApplicationUser user)
        {

            var send = repo.All<Message>().Where(s => s.SenderId == user.Id).ToList();
            var receive = repo.All<Message>().Where(r => r.ReceiverId == user.Id).ToList();
            var messages = new List<Message>();
            foreach (var item in send)
            {
                messages.Add(item);
            }
            foreach (var item in receive)
            {
                messages.Add(item);
            }
            messages.OrderByDescending(c => c.CreatedOn);
           // await CreateChat(messages, user.Id);
            return messages;
        }

        //public async Task CreateChat(List<Message> messages,string userId)
        //{
        //    var chat = new List<Message>();
        //    foreach (var item in messages)
        //    {
                
        //    }
        //}
    }
}
