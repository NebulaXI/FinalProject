using SkiProject.Core.Contracts;
using SkiProject.Core.Models;
using SkiProject.Infrastructure.Data.Common;
using SkiProject.Infrastructure.Data.Models.Account;
using SkiProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SkiProject.Controllers
{
    public class CardController : BaseController
    {
        
        private readonly ICardService cardService;

        public CardController(ICardService _cardService)
        {
            cardService = _cardService;
        }

        [HttpGet]
        public IActionResult CreateNewCard()
        {
            var model = new BankCardViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewCard(BankCardViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var card = new UserBankCard()
            {
                CardNumber = model.CardNumber,
                Month = model.Month,
                Year = model.Year,
                CVV = model.CVV,
                CardHolderName = model.CardHolderName,
                UserId = userId
            };
            await cardService.UpdateCardInfo();
            return RedirectToAction("Index", "Home");
        }
    }
}
