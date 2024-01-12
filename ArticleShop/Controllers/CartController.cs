using ArticleShop.Models;
using ArticleShop.Models.Database;
using ArticleShop.Repositories.ArticleRepository;
using ArticleShop.Repositories.CartRepository;
using ArticleShop.Repositories.CategoryRepository;
using ArticleShop.Repositories.ImageRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Buffers;
using System.Collections.Generic;
using static ArticleShop.Models.CartViewModel;

namespace ArticleShop.Controllers
{
    [Authorize(Policy = "IsNotAdmin")]
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<ActionResult> Index()
        {
            var cartArticles = await _cartRepository.GetArticlesInCartAsync(HttpContext);
            var cookies = HttpContext.Request.Cookies;

            if (cookies != null)
            {
                var roleCookie = cookies["role"];
                TempData["role"] = roleCookie;
            }
            return View(new CartViewModel(cartArticles.Select(kvp => new CartArticle(kvp.Key, kvp.Value)).OrderBy(c => c.Article.Name)));
        }

        public ActionResult AddToCart(Guid articleId)
        {
            var quantity = _cartRepository.AddToCart(HttpContext, articleId);
            TempData[articleId.ToString()] = quantity;
            return RedirectToAction(nameof(Index));
        }

        public ActionResult RemoveFromCart(Guid articleId)
        {
            int remaining = _cartRepository.RemoveFromCart(HttpContext, articleId);
            if (remaining > 0)
                TempData[articleId.ToString()] = remaining;
            else
                TempData.Remove(articleId.ToString());
            return RedirectToAction(nameof(Index));
        }

        public ActionResult RemoveAllFromCart(Guid articleId)
        {
            _cartRepository.RemoveAllFromCart(HttpContext, articleId);
            TempData.Remove(articleId.ToString());
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        [HttpGet]
        public ActionResult FinalizeOrder()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
