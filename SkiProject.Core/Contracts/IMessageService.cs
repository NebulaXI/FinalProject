﻿using SkiProject.Core.Models;
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
        Task<ApplicationUser> FindUserByName(string userName);
        Task<ApplicationUser> FindUserById(string id);
        Task<Message> AddMessageInDB(SendMessageModel model);
        Task AddMessageToUser(ApplicationUser user, Message message);
        Task<List<Message>> GetAllMessages(ApplicationUser user);
    }
}
