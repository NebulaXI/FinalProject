using Microsoft.AspNetCore.Mvc;
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
        private readonly IAccountService accountService;
        public MessageService(IRepository _repo,IAccountService _accountService)
        {
            this.repo = _repo;
            this.accountService = _accountService;
        }

     

        /// <summary>
        /// Adds message to the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
        


        /// <summary>
        /// Returns a collection of all chats of the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<List<ChatViewModel>> GetAllChats(ApplicationUser user)
        {

            var messages = await GetMessagesOfUser(user);
            var chats = await GroupMessagesToChats(messages, user);
            return chats;
        }

        /// <summary>
        /// Gets the messages of the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Group user messages to chat pairs
        /// </summary>
        /// <param name="messages"></param>
        /// <param name="user"></param>
        /// <returns></returns>
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
                var user1 = await accountService.GetCurrentUserById(item.Value);
                var user2 = await accountService.GetCurrentUserById(item.Key);
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

        /// <summary>
        /// Returns all messages between users
        /// </summary>
        /// <param name="user2Id"></param>
        /// <param name="user1Id"></param>
        /// <returns></returns>
        public async Task<List<Message>> GetMessagesBetweenUsers (string user2Id,string user1Id)
        {
            var mes = repo.All<Message>().Where(s => s.SenderId == user2Id && s.ReceiverId == user1Id
                    || s.SenderId == user1Id && s.ReceiverId == user2Id).OrderByDescending(c => c.CreatedOn).ToList();
            return mes;
        }
       
        public async Task<bool> CheckIfAddMessageInDBIsSuccessful(ApplicationUser sender,int senderMesCountBefore,
            ApplicationUser receiver,int receiverMesCountBefore)
        {
            var mesOfSender = await GetMessagesOfUser(sender);
            var mesOfReceiver = await GetMessagesOfUser(receiver);
            if (mesOfSender.Count()>senderMesCountBefore && mesOfReceiver.Count()>receiverMesCountBefore)
            {
                return true;
            }
            return false;
        }

        public async Task ChangeReceiverLayout(ApplicationUser receiver)
        {
            
        }
    }
}
