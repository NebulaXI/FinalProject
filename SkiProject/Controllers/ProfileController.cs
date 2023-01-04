using Microsoft.AspNetCore.Mvc;
using SkiProject.Core.Contracts;
using SkiProject.Core.Models;
using System.Security.Claims;

namespace SkiProject.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IMessageService mesService;
        private readonly IAccountService accountService;

        public ProfileController(IMessageService _mesService, IAccountService _accountService)
        {
            this.mesService = _mesService;
            this.accountService = _accountService;
        }
        public async Task<IActionResult> Index()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await accountService.GetCurrentUserById(userId);
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
            var user = await accountService.GetCurrentUserById(userId);
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
            var user = await accountService.GetCurrentUserByUsername(username);
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
            var sender = await accountService.GetCurrentUserById(senderId);
            var receiverUserName = HttpContext.Request.Cookies["visited_profile"];
            var receiver = await accountService.GetCurrentUserByUsername(receiverUserName);
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
