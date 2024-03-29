﻿using ArticleShop.Models;
using ArticleShop.Models.Database;
using ArticleShop.Repositories.ArticleRepository;
using ArticleShop.Repositories.CartRepository;
using ArticleShop.Repositories.CategoryRepository;
using ArticleShop.Repositories.ImageRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
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
            TempData["role"] = HttpContext.Request.Cookies["role"];
            IEnumerable<SelectListItem> categories = await GetCategoriesWithAllOption();
            
            return View(new ShopViewModel(
                searchValue == null ? await _articleRepository.GetAllAsync() : await GetFilteredArticles(searchValue),
                await GetArticleIdToQuantityInCart(),
                categories
                ));
        }

        private async Task<Dictionary<Guid, int>> GetArticleIdToQuantityInCart()
        {
            var articlesInCart = await _cartRepository.GetArticlesInCartAsync(HttpContext);
            return articlesInCart.Select(kvp => KeyValuePair.Create(kvp.Key.Id, kvp.Value)).ToDictionary();
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
                await GetArticleIdToQuantityInCart(),
                await GetCategoriesWithAllOption()
            );
            return View(nameof(Index), model);
        }

        [HttpGet]
        public ActionResult AddToCart(Guid articleId)
        {
            var quantity = _cartRepository.AddToCart(HttpContext, articleId);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult RemoveFromCart(Guid articleId)
        {
            _cartRepository.RemoveFromCart(HttpContext, articleId);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult ChooseRole(string role)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddSeconds(60 * 60 * 24 * 7);
            HttpContext.Response.Cookies.Append("role", role, option);
            TempData["role"] = role;
            return RedirectToAction(nameof(Index));
        }

    }
}
