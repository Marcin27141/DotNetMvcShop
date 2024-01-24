using ArticleShop.Models.Database;
using ArticleShop.Repositories.ArticleCleanUp;
using ArticleShop.Repositories.ArticleRepository;
using ArticleShop.Repositories.CookieRepository;
using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Claims;
using static ArticleShop.Models.CartViewModel;

namespace ArticleShop.Repositories.CartRepository
{
    public class CartRepository : ICartRepository
    {
        private readonly ICookieNameProvider _cookieProvider;
        private readonly IArticleRepository _articleRepository;
        private const int WEEK_TIME_SECONDS = 60 * 60 * 24 * 7;

        public CartRepository(
            ICookieNameProvider cookieNameProvider,
            IArticleRepository articleRepository)
        {
            _cookieProvider = cookieNameProvider;
            _articleRepository = articleRepository;
        }

        public int AddToCart(HttpContext context, Guid articleId)
        {
            var cookieName = _cookieProvider.GetCookieNameForUser(articleId.ToString(), context.User);
            var existing = context.Request.Cookies[cookieName];
            var numberOfItems = 1;
            if (existing != null && int.TryParse(existing, out numberOfItems))
                numberOfItems++;
            SetCookie(context, cookieName, numberOfItems.ToString(), WEEK_TIME_SECONDS);
            return numberOfItems;
        }

        private async Task<Article?> TryGetArticleFromCookie(string cookie)
        {
            var isGuid = Guid.TryParse(cookie, out Guid guid);
            return !isGuid ? null : await _articleRepository.GetByIdAsync(guid);
        }

        public async Task<Dictionary<Article, int>> GetArticlesInCartAsync(HttpContext context)
        {
            var cartArticles = new Dictionary<Article, int>();
            var userCookies = GetUserCookies(context);

            foreach (var cookie in userCookies)
            {
                var article = await TryGetArticleFromCookie(cookie.Key);
                if (article != null && int.TryParse(cookie.Value, out int quantity))
                    cartArticles.Add(article, quantity);
            }

            return cartArticles;
        }

        private IEnumerable<KeyValuePair<string, string>> GetUserCookies(HttpContext context)
        {
            return context.Request.Cookies
                .Where(c => _cookieProvider.IsCookieBelongingToUser(c.Key, context.User))
                .Select(c => KeyValuePair.Create(
                    _cookieProvider.GetKeyFromCookie(c.Key, context.User),
                    c.Value));
        }

        private static void SetCookie(HttpContext context, string key, string value, int? numberOfSeconds = null)
        {
            CookieOptions option = new();
            if (numberOfSeconds.HasValue)
                option.Expires = DateTime.Now.AddSeconds(numberOfSeconds.Value);
            context.Response.Cookies.Append(key, value, option);
        }

        public int GetQuantityInCart(HttpContext context, Guid articleId)
        {
            var cookieKey = _cookieProvider.GetCookieNameForUser(articleId.ToString(), context.User);
            var quantity = context.Request.Cookies[cookieKey];
            return
                (quantity != null && int.TryParse(quantity, out int result))
                ? result : 0;
        }

        public int RemoveFromCart(HttpContext context, Guid id)
        {
            var cookieKey = _cookieProvider.GetCookieNameForUser(id.ToString(), context.User);
            var existing = context.Request.Cookies[cookieKey];
            if (existing != null && int.TryParse(existing, out int numberOfItems))
            {
                if (numberOfItems > 1)
                {
                    SetCookie(context, cookieKey, (numberOfItems - 1).ToString(), WEEK_TIME_SECONDS);
                    return numberOfItems - 1;
                }
                else
                    context.Response.Cookies.Delete(cookieKey);
            }
            return 0;
        }

        public void RemoveAllFromCart(HttpContext context, Guid id)
        {
            var cookieKey = _cookieProvider.GetCookieNameForUser(id.ToString(), context.User);
            var existing = context.Request.Cookies[cookieKey];
            if (existing != null)
                context.Response.Cookies.Delete(cookieKey);
        }

        public void RemoveAllFromCart(HttpContext context)
        {
            foreach (var cookie in context.Request.Cookies)
                if (_cookieProvider.IsCookieBelongingToUser(cookie.Key, context.User))
                    context.Response.Cookies.Delete(cookie.Key);
        }
    }
}
