using Microsoft.AspNetCore.Mvc;
using SkiProject.Core.Contracts;
using SkiProject.Core.Models;
using SkiProject.Infrastructure.Data.Models;
using SkiProject.Infrastructure.Data.Models.Account;
using System.Security.Claims;
using System.Xml.Linq;

namespace SkiProject.Controllers
{
    public class MessageController : BaseController
    {
        private readonly IMessageService mesService;
        private readonly IAccountService accountService;
        public MessageController(IMessageService _mesService,IAccountService _accountService)
        {
            this.mesService = _mesService;
            this.accountService = _accountService;
        }
        public IActionResult Index()
        {
            return View();
        }
        //public async Task<IActionResult> GetAllPostsBetweenUsers()
        //{
        //    var senderId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var sender = await mesService.FindUserById(senderId);

        //    var receiver = await mesService.FindUserById(messageToPass.ReceiverId);
        //    List<Message> allMessages = new List<Message>();
        //    if (sender.SentMessages!=null)
        //    {
        //        List<Message> sentMessages = sender.SentMessages.Where(r => r.ReceiverId == receiver.Id).ToList();
        //        foreach (var item in sentMessages)
        //        {
        //            allMessages.Add(item);
        //        }
        //    }
        //    if (sender.ReceivedMessages!=null)
        //    {
        //        List<Message> receivedMessages = sender.ReceivedMessages.Where(r => r.SenderId == receiver.Id).ToList();

        //        foreach (var item in receivedMessages)
        //        {
        //            allMessages.Add(item);
        //        }
        //    }
            
            
        //    allMessages.OrderByDescending(c=>c.CreatedOn);
        //    var model = new ShowMessageViewModel()
        //    {
        //        Receiver = receiver,
        //        ReceiverId = receiver.Id,
        //        Sender = sender,
        //        SenderId = senderId,
        //        Messages = allMessages
        //    };
        //    return View(model);
        //}

        

        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {
            var model = new SendMessageModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(SendMessageModel DTOmodel)
        {
            
            var senderId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var sender = await accountService.GetCurrentUserById(senderId);
            var ownerUserName = HttpContext.Request.Cookies["visited_ad_owner"];
            var receiver = await accountService.GetCurrentUserByUsername(ownerUserName);
            var model = new SendMessageModel()
            {
                Content = DTOmodel.Content,
                ReceiverName = DTOmodel.ReceiverName,
                Receiver = receiver,
                ReceiverId = receiver.Id,
                SenderId = senderId,
                Sender = sender
            };
            foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors)) { int a = 5; }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var senderMes = await mesService.GetMessagesOfUser(sender);
            var senderMesCount = senderMes.Count();
            var receiverMes = await mesService.GetMessagesOfUser(receiver);
            var receiverMesCount = receiverMes.Count();
            var message = await mesService.AddMessageInDB(model);
            if (await mesService.CheckIfAddMessageInDBIsSuccessful(sender, senderMesCount, receiver, receiverMesCount))
            {
                ViewBag["IsNewMessage"] = true;
            }
            
            return View();
        }

        public async Task<IActionResult> ShowChats()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await accountService.GetCurrentUserById(userId);
            var chats = await mesService.GetAllChats(user);
            if (chats.Count==0)
            {
                return View("NoMessagesView");
            }
            var model = new ShowMessageViewModel() { Chats = chats };
            return View(model);
        }

        public async Task<IActionResult> ShowMessages(string user2Id)
        {

            HttpContext.Response.Cookies.Append("user2_id", user2Id);
            var user1Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user1 = await accountService.GetCurrentUserById(user1Id);
            var user2 = await accountService.GetCurrentUserById(user2Id);
            var mes= await mesService.GetMessagesBetweenUsers(user2.Id, user1.Id);
            mes.OrderBy(c => c.CreatedOn);
            TempData["user1"] = user1Id;
            TempData["createdByUser1"] = user1.UserName;
            TempData["createdByUser2"] = user2.UserName;
            var model = new ChatViewModel()
            {
                User1 = user1,
                User2 = user2,
                user2Id = user2Id,
                user1Id = user1Id,
                MessagesBetweenUsers = mes
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddNewMessage()
        {
            var model = new ChatViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewMessage(ChatViewModel model)
        {

            var user1Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user1 = await accountService.GetCurrentUserById(user1Id);
            var user2Id =HttpContext.Request.Cookies["user2_id"];
            var user2 = await accountService.GetCurrentUserById(user2Id);
            var Sendmodel = new SendMessageModel()
            {
                Content = model.NewMessageContent,
                ReceiverName = user2.UserName,
                Receiver = user2,
                ReceiverId = user2.Id,
                SenderId = user1Id,
                Sender = user1
            };
            var message = await mesService.AddMessageInDB(Sendmodel);
            return RedirectToAction("ShowMessages",new {user2Id=user2Id});
        }

    }
}
