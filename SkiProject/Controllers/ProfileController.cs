using Microsoft.AspNetCore.Mvc;
using SkiProject.Core.Contracts;
using SkiProject.Core.Models;
using System.Security.Claims;

namespace SkiProject.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IMessageService mesService;
        public ProfileController(IMessageService _mesService)
        {
            this.mesService = _mesService;
        }
        public async Task<IActionResult> Index()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await mesService.FindUserById(userId);
            var model = new ProfileViewModel()
            {
                UserName = user.UserName,
                Birthday = user.Birthday.Date,
                CreatedOn = user.ProfileCreatedOn.Value.Date

            };

            return View(model);
        }

        public async Task<IActionResult> ViewOtherProfile(string userId)
        {
            var user = await mesService.FindUserById(userId);
            HttpContext.Response.Cookies.Append("visited_profile", user.UserName);
            var model = new ProfileViewModel()
            {
                UserName = user.UserName,
                Birthday = user.Birthday.Date,
                CreatedOn = user.ProfileCreatedOn.Value.Date

            };
            return View("Index", model);
        }
        public async Task<IActionResult> ViewOtherProfileByUsername(string username)
        {
            var user = await mesService.FindUserByName(username);
            HttpContext.Response.Cookies.Append("visited_profile", user.UserName);
            var model = new ProfileViewModel()
            {
                UserName = user.UserName,
                Birthday = user.Birthday.Date,
                CreatedOn = user.ProfileCreatedOn.Value.Date

            };
            return View("Index", model);
        }

        [HttpGet]
        public async Task<IActionResult> SendMessageProfile()
        {
            var model = new SendMessageModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SendMessageProfile(SendMessageModel DTOmodel)
        {

            var senderId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var sender = await mesService.FindUserById(senderId);
            var receiverUserName = HttpContext.Request.Cookies["visited_profile"];
            var receiver = await mesService.FindUserByName(receiverUserName);
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

            var message = await mesService.AddMessageInDB(model);
            return RedirectToAction("ShowMessages", "Message", new { user2Id = receiver.Id });
        }
    }
}
