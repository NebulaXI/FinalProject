using Microsoft.AspNetCore.Mvc;
using SkiProject.Core.Contracts;
using SkiProject.Core.Models;
using SkiProject.Infrastructure.Data.Models;
using SkiProject.Infrastructure.Data.Models.Account;
using System.Security.Claims;

namespace SkiProject.Controllers
{
    public class MessageController : BaseController
    {
        private readonly IMessageService mesService;
        public MessageController(IMessageService _mesService)
        {
            this.mesService = _mesService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAllPostsBetweenUsers()
        {
            var senderId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var sender = await mesService.FindUserById(senderId);

            var receiver = await mesService.FindUserById(messageToPass.ReceiverId);
            List<Message> allMessages = new List<Message>();
            if (sender.SentMessages!=null)
            {
                List<Message> sentMessages = sender.SentMessages.Where(r => r.ReceiverId == receiver.Id).ToList();
                foreach (var item in sentMessages)
                {
                    allMessages.Add(item);
                }
            }
            if (sender.ReceivedMessages!=null)
            {
                List<Message> receivedMessages = sender.ReceivedMessages.Where(r => r.SenderId == receiver.Id).ToList();

                foreach (var item in receivedMessages)
                {
                    allMessages.Add(item);
                }
            }
            
            
            allMessages.OrderByDescending(c=>c.CreatedOn);
            var model = new ShowMessageViewModel()
            {
                Receiver = receiver,
                ReceiverId = receiver.Id,
                Sender = sender,
                SenderId = senderId,
                Messages = allMessages
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {
            var model = new SendMessageModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(SendMessageModel DTOmodel)
        {
            var user = await mesService.FindUserByName(DTOmodel.ReceiverName);
            var senderId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var sender = await mesService.FindUserById(senderId);
            var model = new SendMessageModel()
            {
                Content = DTOmodel.Content,
                ReceiverName = DTOmodel.ReceiverName,
                Receiver = user,
                ReceiverId = user.Id,
                SenderId = senderId,
                Sender = sender
            };
            foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors)) { int a = 5; }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var message = await mesService.AddMessageInDB(model);
            await mesService.AddMessageToReceived(user, message);
            await mesService.AddMessageToSent(sender, message);
            return View();
        }
    }
}
