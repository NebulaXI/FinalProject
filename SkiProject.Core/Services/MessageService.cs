using SkiProject.Core.Contracts;
using SkiProject.Core.Models;
using SkiProject.Infrastructure.Data.Common;
using SkiProject.Infrastructure.Data.Models;
using SkiProject.Infrastructure.Data.Models.Account;
using SkiProject.Infrastructure.Data.Models.Shop;
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
            await repo.AddAsync<Message>(message);
            await repo.SaveChangesAsync();
            return message;
        }
        



        public async Task<List<ChatViewModel>> GetAllChats(ApplicationUser user)
        {

            var messages = await GetMessagesOfUser(user);
            var chats = await GroupMessagesToChats(messages, user);
            return chats;
        }

        public async Task<List<Message>> GetMessagesOfUser(ApplicationUser user)
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
            return messages;
        }
        public async Task<List<ChatViewModel>> GroupMessagesToChats(List<Message> messages,ApplicationUser user)
        {
            Dictionary<string, string> chat = new Dictionary<string, string>();

            foreach (var item in messages)
            {
                bool IsChatExist = false;
                if (item.SenderId == user.Id)
                {
                    var receiverId = item.ReceiverId;
                    if (chat.ContainsKey(item.ReceiverId) && chat[item.ReceiverId].Equals(user.Id))
                    {
                        IsChatExist = true;
                    }
                    else
                    {
                        chat.Add(receiverId, user.Id);
                    }
                }

                if (item.ReceiverId == user.Id)
                {
                    var senderId = item.SenderId;
                    if (chat.ContainsKey(senderId) && chat[senderId].Equals(user.Id))
                    {
                        IsChatExist = true;
                    }
                    else
                    {
                        chat.Add(senderId, user.Id);
                    }
                }
            }
            var chats = new List<ChatViewModel>();
            foreach (var item in chat)
            {
                var user1 = await FindUserById(item.Value);
                var user2 = await FindUserById(item.Key);
                var chatModel = new ChatViewModel()
                {
                    User1 = user1,
                    User2 = user2,
                    user1Id = user1.Id,
                    user2Id = user2.Id,
                    MessagesBetweenUsers = messages.Where(s => s.SenderId == item.Key && s.ReceiverId == item.Value
                    || s.SenderId == item.Value && s.ReceiverId == item.Key).OrderByDescending(c => c.CreatedOn).ToList()
                };
                chats.Add(chatModel);

            }
            return chats;
        }

        public async Task<List<Message>> GetMessagesBetweenUsers (string user2Id,string user1Id)
        {
            var mes = repo.All<Message>().Where(s => s.SenderId == user2Id && s.ReceiverId == user1Id
                    || s.SenderId == user1Id && s.ReceiverId == user2Id).OrderByDescending(c => c.CreatedOn).ToList();
            return mes;
        }
       
    }
}
