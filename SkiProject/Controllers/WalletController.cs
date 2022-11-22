using SkiProject.Core.Contracts;
using SkiProject.Core.Models;
using SkiProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SkiProject.Controllers
{
    public class WalletController : BaseController
    {
        private readonly IWalletService walletService;
        public WalletController(IWalletService _walletService)
        {
            this.walletService = _walletService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task< IActionResult> AmountInWallet()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentWallet = await walletService.GetCurrentWallet(userId);
            var amount = walletService.GetAmountInWallet(currentWallet);
            ViewBag.AmountInWallet = amount;
            return View();
        }

        [HttpGet]
        public IActionResult AddMoneyToWallet()
        {
            var model = new BankCardViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task <IActionResult> AddMoneyToWallet(BankCardViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentWallet = await walletService.GetCurrentWallet(userId);
            await walletService.Add(currentWallet, model.Amount);
            return RedirectToAction("Home/Index");
        }

        //public async Task<IActionResult> Withdraw()
        //{

        //}
    }
}
