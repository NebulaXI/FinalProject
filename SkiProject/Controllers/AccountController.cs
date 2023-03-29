using SkiProject.Core.Contracts;
using SkiProject.Core.Models;
using SkiProject.Core.Services;
using SkiProject.Infrastructure.Data;
using SkiProject.Infrastructure.Data.Models.Account;
using SkiProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ganss.Xss;
using SkiProject.Infrastructure.Data.Models;
using SkiProject.Infrastructure.Data.Models.Shop;
using SendGrid.Helpers.Mail;
using SendGrid;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNet.Identity;

namespace SkiProject.Controllers
{
    
    public class AccountController : BaseController
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IEmailSender emailSender;
        public AccountController(Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager,
            IEmailSender _emailSender)
        {
            userManager = _userManager;
            signInManager = _signInManager;
           emailSender = _emailSender;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            var model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var sanitizer = new HtmlSanitizer();            
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //UserAlreadyExistsAsync(model);

            var user = new ApplicationUser()
            {
                
                Email = sanitizer.Sanitize(model.Email),
                UserName = sanitizer.Sanitize(model.Username),
                FirstName =sanitizer.Sanitize (model.FirstName),
                LastName =sanitizer.Sanitize( model.LastName),
                EmailConfirmed = true,
                Birthday = model.Birthdate,
                Posts = new List<Post>(),
                CreatedTopics = new List<ForumTopic>(),
                CreatedProducts = new List<Product>(),
                CreatedAdvertisments = new List<Advertisment>(),
                Messages = new List<Message>(),
                ProfileCreatedOn=DateTime.Now,
                Gender = model.Gender
            };
            //When creating user with password
            //If we are creating an user without a password=>(user)
            var result = await userManager.CreateAsync(user, model.Password);
            //await userManager
            //    .AddClaimAsync(user, new System.Security.Claims.Claim(ClaimTypeConstants.FirstName, user.FirstName ?? user.Email));
           
            if (result.Succeeded)
            {
                //isPersistent on the registration false, changes the cookie 
                var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);

                await emailSender.SendEmailAsync(user.Email,"Confirm your account",
                    $"Please confirm your account by clicking this link: <a href='{callbackUrl}'>link</a>");
                //await signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var item in result.Errors)
            {

                ModelState.AddModelError("", item.Description);
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
                return View("Error");
            var result = await userManager.ConfirmEmailAsync(user, token);
            return View(result.Succeeded ? nameof(ConfirmEmail) : "Error");
        }

        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SuccessRegistration()
        {
            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl = null)
        {
            var model = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var sanitizer = new HtmlSanitizer();
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByNameAsync(sanitizer.Sanitize(model.Username));
            if (user != null)
            {

                var result = await signInManager.PasswordSignInAsync(user,sanitizer.Sanitize( model.Password), false, false);

                if (result.Succeeded)
                {
                    await emailSender.SendEmailAsync(user.Email, "Welcome email", "Welcome to Ski Forum");
                    if (model.ReturnUrl != null)
                    {
                        //When the user is trying to access a page without login
                        //and after that the user logs in this redirect to the previous page 
                        return Redirect(model.ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Invalid login");
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}
