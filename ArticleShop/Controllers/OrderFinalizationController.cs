using ArticleShop.Models;
using ArticleShop.Repositories.CartRepository;
using Microsoft.AspNetCore.Mvc;
using static ArticleShop.Models.CartViewModel;

namespace ArticleShop.Controllers
{
    public class OrderFinalizationController : Controller
    {
        private readonly ICartRepository _cartRepository;

        public OrderFinalizationController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<ActionResult> Index()
        {
            var cartArticles = await _cartRepository.GetArticlesInCartAsync(HttpContext);
            var cookies = HttpContext.Request.Cookies;

            var order = cartArticles.Select(kvp => new CartArticle(kvp.Key, kvp.Value)).OrderBy(c => c.Article.Name);
            return View(new OrderFinalizationViewModel()
            {
                OrderedArticles = order,
                DeliveryInfo = new DeliveryViewModel(),
                PaymentOption = null
            });
        }
    }
}
