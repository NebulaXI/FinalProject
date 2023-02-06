using Microsoft.AspNetCore.SignalR;
using SkiProject.Core.Contracts;
using SkiProject.Core.Models;

namespace SkiProject.Hubs
{
    public class ChatHub:Hub
    {
        private readonly IMessageService messageService;
        public ChatHub(IMessageService _messageService)
        {
            this.messageService = _messageService;
        }

        public async Task SendMessage(string user1,string user2,string sender,string receiver,string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",user1,user2,sender,receiver,message);
        }

        //public async Task SendMessage(string message)
        //{
        //    var user1Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var user1 = await accountService.GetCurrentUserById(user1Id);
        //    var user2Id =HttpContext.Request.Cookies["user2_id"];
        //    var user2 = await accountService.GetCurrentUserById(user2Id);
        //    var Sendmodel = new SendMessageModel()
        //    {
        //        Content = model.NewMessageContent,
        //        ReceiverName = user2.UserName,
        //        Receiver = user2,
        //        ReceiverId = user2.Id,
        //        SenderId = user1Id,
        //        Sender = user1
        //    };
        //    ChatViewModel model = new ChatViewModel();
        //    model.NewMessageContent = message;
        //    await messageService.AddMessageInDB
        //}
    }
}
