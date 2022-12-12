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
            var model = new ProfileViewModel();
            if (user.ProfileCreatedOn!=null)
            {
                model.UserName = user.UserName;
                model.Birthday = user.Birthday.Date;
                model.CreatedOn = user.ProfileCreatedOn.Value.Date;
                
            }
            else
            {
                model.UserName = user.UserName;
                model.Birthday = user.Birthday.Date;
            }
            
            return View(model);
        }

    }
}
