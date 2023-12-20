using ArticleShop.Models;
using ArticleShop.Models.Database;
using ArticleShop.Repositories.ArticleRepository;
using ArticleShop.Repositories.CategoryRepository;
using ArticleShop.Repositories.ImageRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Buffers;
using System.Collections.Generic;

namespace ArticleShop.Controllers
{
    public class ShopController : Controller
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ShopController(IArticleRepository articleRepository, ICategoryRepository categoryRepository)
        {
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index(string? searchValue)
        {
            IEnumerable<SelectListItem> categories = await GetCategoriesWithAllOption();
            return View(new ShopViewModel(
                searchValue == null ? await _articleRepository.GetAllAsync() : await GetFilteredArticles(searchValue),
                categories
                ));
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToCart(Guid articleId)
        {
            var existing = Request.Cookies[articleId.ToString()];
            var numberOfItems = 1;
            if (existing != null)
            {
                numberOfItems = int.Parse(existing);
                numberOfItems++;
            }
            SetCookie(articleId.ToString(), numberOfItems.ToString(), 60 * 60 * 24 * 7);
            TempData[articleId.ToString()] = numberOfItems;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveFromCart(Guid articleId)
        {
            var existing = Request.Cookies[articleId.ToString()];
            if (existing != null)
            {
                var numberOfItems = int.Parse(existing);
                if (numberOfItems > 1)
                {
                    SetCookie(articleId.ToString(), (numberOfItems - 1).ToString(), 60 * 60 * 24 * 7);
                    TempData[articleId.ToString()] = (numberOfItems - 1);
                }
                else
                {
                    Response.Cookies.Delete(articleId.ToString());
                    TempData.Remove(articleId.ToString());
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private void SetCookie(string key, string value, int? numberOfSeconds = null)
        {
            CookieOptions option = new CookieOptions();
            if (numberOfSeconds.HasValue)
                option.Expires = DateTime.Now.AddSeconds(numberOfSeconds.Value);
            Response.Cookies.Append(key, value, option);
        }
    }
}
