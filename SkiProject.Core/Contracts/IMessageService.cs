using SkiProject.Core.Models;
using SkiProject.Infrastructure.Data.Models;
using SkiProject.Infrastructure.Data.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Core.Contracts
{
    public interface IMessageService
    {
        /// <summary>
        /// Gets the user by username
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<ApplicationUser> FindUserByName(string userName);

        /// <summary>
        /// Gets the user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApplicationUser> FindUserById(string id);

        /// <summary>
        /// Adds message to the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Message> AddMessageInDB(SendMessageModel model);

        /// <summary>
        /// Returns a collection of all chats of the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<List<ChatViewModel>> GetAllChats(ApplicationUser user);

        /// <summary>
        /// Gets the messages of the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<List<Message>> GetMessagesOfUser(ApplicationUser user);

        /// <summary>
        /// Group user messages to chat pairs
        /// </summary>
        /// <param name="messages"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<List<ChatViewModel>> GroupMessagesToChats(List<Message> messages, ApplicationUser user);

        /// <summary>
        /// Returns all messages between users
        /// </summary>
        /// <param name="user2Id"></param>
        /// <param name="user1Id"></param>
        /// <returns></returns>
        Task<List<Message>> GetMessagesBetweenUsers(string user2Id, string user1Id);
    }
}
