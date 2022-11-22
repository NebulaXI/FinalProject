using SkiProject.Core.Contracts;
using SkiProject.Core.Models;
using SkiProject.Core.Services;
using SkiProject.Infrastructure.Data;
using SkiProject.Infrastructure.Data.Models.Account;
using SkiProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SkiProject.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IWalletService walletService;

        public AccountController(UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager,IWalletService _walletService)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            walletService = _walletService;
        }

        /// <summary>
        /// Check if there is already user with the same email and/or username
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
       
        //[AllowAnonymous]
        //public async Task UserAlreadyExistsAsync(RegisterViewModel model)
        //{
        //    var chekUsername = await userManager.FindByNameAsync(model.Username);
        //    if (chekUsername != null)
        //    {
        //        StatusMessage = "User name already taken. Select a different username.";
        //    }
        //    var checkEmail = await userManager.FindByEmailAsync(model.Email);
        //    if (checkEmail!=null)
        //    {
        //        StatusMessage = "There is already an user registered with the same email.";
        //    }
        //}
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //UserAlreadyExistsAsync(model);

            var user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailConfirmed = true,
                Birthday = model.Birthdate
            };
            //When creating user with password
            //If we are creating an user without a password=>(user)
            var result = await userManager.CreateAsync(user, model.Password);
            //await userManager
            //    .AddClaimAsync(user, new System.Security.Claims.Claim(ClaimTypeConstants.FirstName, user.FirstName ?? user.Email));
           
            if (result.Succeeded)
            {
                //isPersistent on the registration false, changes the cookie 
                await signInManager.SignInAsync(user, isPersistent: false);
                await walletService.Create(user.Id);
               
                return RedirectToAction("Index", "Home");
            }

            foreach (var item in result.Errors)
            {

                ModelState.AddModelError("", item.Description);
            }
            return View(model);
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null)
            {

                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
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
