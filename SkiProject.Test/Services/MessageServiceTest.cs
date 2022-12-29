using SkiProject.Core.Models;
using SkiProject.Core.Services;
using SkiProject.Infrastructure.Data.Common;
using SkiProject.Infrastructure.Data.Models;
using SkiProject.Infrastructure.Data.Models.Account;
using SkiProject.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Test.Services
{
    public class MessageServiceTest
    {
        [Fact]
        public async Task FindUserByNameShouldReturnUser()
        {
            var data = DBMock.Instance;
            var repo = new Repository(data);
            var messageService = new MessageService(repo);
            var user1 = new ApplicationUser()
            {
                FirstName = "1",
                LastName = "1",
                Birthday = DateTime.Now,
                UserName = "1",
                Email = $"1@mail.com"
            };
            data.Users.Add(user1);
            var user2 = new ApplicationUser()
            {
                FirstName = "2",
                LastName = "2",
                Birthday = DateTime.Now,
                UserName = "2",
                Email = $"2@mail.com"
            };
            data.Users.Add(user2);
            await data.SaveChangesAsync();

            var resultByName = await messageService.FindUserByName(user1.FirstName);
            var resultById = await messageService.FindUserById(user2.Id);

            Assert.NotNull(resultByName);
            Assert.Equal(user1.FirstName, resultByName.FirstName);
            Assert.NotNull(resultById);
            Assert.Equal(user2.Id, resultById.Id);
        }

        [Fact]
        public async Task AddMessageInDb()
        {
            var data = DBMock.Instance;
            var repo = new Repository(data);
            var messageService = new MessageService(repo);
            var sender = new ApplicationUser()
            {
                FirstName = "1",
                LastName = "1",
                Birthday = DateTime.Now,
                UserName = "1",
                Email = "1@mail.com"
            };
            var receiver = new ApplicationUser()
            {
                FirstName = "2",
                LastName = "2",
                Birthday = DateTime.Now,
                UserName = "2",
                Email = "2@mail.com"
            };
            var model = new SendMessageModel()
            {
                Content = "1",
                ReceiverName = receiver.UserName,
                Receiver = receiver,
                ReceiverId = receiver.Id,
                SenderId = sender.Id,
                Sender = sender
            };

            var result = await messageService.AddMessageInDB(model);

            Assert.NotNull(result);
            Assert.Equal(1, data.Messages.Count());
        }

        [Fact]
        public async Task GetMessagesOfUser()
        {
            var data = DBMock.Instance;
            var repo = new Repository(data);
            var messageService = new MessageService(repo);
            var user1 = new ApplicationUser()
            {
                FirstName = "1",
                LastName = "1",
                Birthday = DateTime.Now,
                UserName = "1",
                Email = $"1@mail.com",
                Messages=new List<Message>()
            };
            for (int i = 0; i < 3; i++)
            {
                user1.Messages.Add(new Message { SenderId = "1", ReceiverId = "2", Content = "Message", CreatedOn = DateTime.Now });
            }
            data.Users.Add(user1);
            await data.SaveChangesAsync();

            var result = await messageService.GetMessagesOfUser(user1);

            Assert.NotNull(result);
            Assert.Equal(3, user1.Messages.Count);
        }

        [Fact]
        public async Task GetMessagesBetweenUsers()
        {
            var data = DBMock.Instance;
            var repo = new Repository(data);
            var messageService = new MessageService(repo);
            var user1 = new ApplicationUser()
            {
                FirstName = "1",
                LastName = "1",
                Birthday = DateTime.Now,
                UserName = "1",
                Email = $"1@mail.com",
                Messages = new List<Message>()
            };
            for (int i = 0; i < 3; i++)
            {
                user1.Messages.Add(new Message { SenderId = "1", ReceiverId = "2", Content = "Message", CreatedOn = DateTime.Now });
            }
            data.Users.Add(user1);
            var user2 = new ApplicationUser()
            {
                FirstName = "2",
                LastName = "2",
                Birthday = DateTime.Now,
                UserName = "2",
                Email = $"2@mail.com",
                Messages = new List<Message>()
            };
            for (int i = 0; i < 3; i++)
            {
                user2.Messages.Add(new Message { SenderId = "2", ReceiverId = "1", Content = "Message", CreatedOn = DateTime.Now });
            }
           
            data.Users.Add(user1);
            data.Users.Add(user2);
            await data.SaveChangesAsync();

            var result = await messageService.GetMessagesBetweenUsers(user1.Id, user2.Id);

            Assert.NotNull(result);
            Assert.Equal(6, data.Messages.Count());
        }
    }
}
