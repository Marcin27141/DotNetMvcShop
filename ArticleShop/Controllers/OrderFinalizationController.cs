using ArticleShop.Models;
using ArticleShop.Repositories.CartRepository;
using ArticleShop.Repositories.PaymentRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static ArticleShop.Models.CartViewModel;

namespace ArticleShop.Controllers
{
    [Authorize]
    public class OrderFinalizationController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly IPaymentRepository _paymentRepository;

        public OrderFinalizationController(
            ICartRepository cartRepository,
            IPaymentRepository paymentRepository)
        {
            _cartRepository = cartRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task<ActionResult> Index()
        {
            return View(await GetOrderFinalizationViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Finalize([FromForm] DeliveryViewModel deliveryInfo, Guid paymentOption)
        {
            if (!ModelState.IsValid && paymentOption != Guid.Empty)
            {
                var finalizationModel = await GetOrderFinalizationViewModel();
                finalizationModel.DeliveryInfo = deliveryInfo;
                return View(nameof(Index), finalizationModel);
            }
            TempData["finalizationModel"] = JsonSerializer.Serialize<DeliveryViewModel>(deliveryInfo);    
            return RedirectToAction(nameof(Confirm), new { paymentOption });
        }

        public async Task<ActionResult> Confirm(Guid paymentOption)
        {
            var deliveryViewModel = JsonSerializer.Deserialize<DeliveryViewModel>(TempData["finalizationModel"].ToString());
            var finalizationModel = await GetOrderFinalizationViewModel();
            finalizationModel.PaymentOption = paymentOption;
            finalizationModel.DeliveryInfo = deliveryViewModel;

            _cartRepository.RemoveAllFromCart(HttpContext);

            return View(finalizationModel);
        }

        private async Task<OrderFinalizationViewModel> GetOrderFinalizationViewModel()
        {
            var cartArticles = await _cartRepository.GetArticlesInCartAsync(HttpContext);
            var cookies = HttpContext.Request.Cookies;

            var order = cartArticles.Select(kvp => new CartArticle(kvp.Key, kvp.Value)).OrderBy(c => c.Article.Name);
            return new OrderFinalizationViewModel(order, _paymentRepository.GetPaymentMethods());
        }
    }
}
