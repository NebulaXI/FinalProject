using Microsoft.AspNetCore.Mvc;
using SkiProject.Core.Contracts;
using SkiProject.Core.Models;
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
        public IActionResult SendMessage()
        {
            var model = new SendMessageModel();
            return View(model);
        }
        public async IActionResult SendMessage(SendMessageModel DTOmodel)
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await mesService.AddMessageInDB(model);

        }
    }
}
