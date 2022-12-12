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
            var userBir = user.Birthday;
            var model = new ProfileViewModel()
            {
                UserName = user.UserName,
                Birthday = userBir.Date
                //CreatedOn= user.ProfileCreatedOn.Value.Date
            };
            return View(model);
        }

    }
}
