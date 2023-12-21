using ArticleShop.Models;
using ArticleShop.Models.Database;
using ArticleShop.Repositories.ArticleRepository;
using ArticleShop.Repositories.CartRepository;
using ArticleShop.Repositories.CategoryRepository;
using ArticleShop.Repositories.ImageRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Buffers;
using System.Collections.Generic;
using static ArticleShop.Models.CartViewModel;

namespace ArticleShop.Controllers
{
    public class ShopController : Controller
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICartRepository _cartRepository;

        public ShopController(
            IArticleRepository articleRepository,
            ICategoryRepository categoryRepository,
            ICartRepository cartRepository)
        {
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;
            _cartRepository = cartRepository;
        }

        public async Task<IActionResult> Index(string? searchValue)
        {
            await SetUpTempData();
            IEnumerable<SelectListItem> categories = await GetCategoriesWithAllOption();
            return View(new ShopViewModel(
                searchValue == null ? await _articleRepository.GetAllAsync() : await GetFilteredArticles(searchValue),
                categories
                ));
        }

        private async Task SetUpTempData()
        {
            if (!TempData.Any(kvp => Guid.TryParse(kvp.Key, out Guid result)))
            {
                var cartArticles = await _cartRepository.GetArticlesInCartAsync(HttpContext);
                foreach (var (article, quantity) in cartArticles)
                {
                    TempData[article.Id.ToString()] = quantity;
                }
            }
        }

        private async Task<IEnumerable<Article>> GetFilteredArticles(string searchValue)
        {
            var articles = await _articleRepository.GetAllAsync();
            var lowerSearch = searchValue.ToLower();
            return articles.Where(a => a.Name.ToLower().Contains(lowerSearch) || a.Category.Name.ToLower().Contains(lowerSearch));
        }

        private async Task<IEnumerable<SelectListItem>> GetCategoriesWithAllOption()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var selectableCategories = categories.Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() }).OrderBy(c => c.Text);
            var withAllOption = selectableCategories.Prepend(new SelectListItem() { Text = "All", Value = "all" });
            return withAllOption;
        }

        [HttpGet]
        public IActionResult Search(string searchValue)
        {
            return RedirectToAction(nameof(Index), new { searchValue });
        }

        [HttpGet]
        public async Task<IActionResult> SearchCategory(string categoryId)
        {
            var articles = await _articleRepository.GetAllAsync();
            var model = new ShopViewModel(
            articles.Where(a => a.CategoryId.ToString().Equals(categoryId)),
            await GetCategoriesWithAllOption()
            );
            return View(nameof(Index), model);
        }

        [HttpGet]
        public ActionResult AddToCart(Guid articleId)
        {
            var quantity = _cartRepository.AddToCart(HttpContext, articleId);
            TempData[articleId.ToString()] = quantity;
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult RemoveFromCart(Guid articleId)
        {
            int remaining = _cartRepository.RemoveFromCart(HttpContext, articleId);
            if (remaining > 0)
                TempData[articleId.ToString()] = remaining;
            else
                TempData.Remove(articleId.ToString());
            return RedirectToAction(nameof(Index));
        }
    }
}
