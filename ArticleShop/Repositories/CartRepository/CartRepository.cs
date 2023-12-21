using ArticleShop.Models.Database;
using ArticleShop.Repositories.ArticleCleanUp;
using ArticleShop.Repositories.ArticleRepository;
using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static ArticleShop.Models.CartViewModel;

namespace ArticleShop.Repositories.CartRepository
{
    public class CartRepository : ICartRepository
    {
        private readonly IArticleRepository _articleRepository;
        private const int WEEK_TIME_SECONDS = 60 * 60 * 24 * 7;

        public CartRepository(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public int AddToCart(HttpContext context, Guid articleId)
        {
            var existing = context.Request.Cookies[articleId.ToString()];
            var numberOfItems = 1;
            if (existing != null && int.TryParse(existing, out numberOfItems))
                numberOfItems++;
            SetCookie(context, articleId.ToString(), numberOfItems.ToString(), WEEK_TIME_SECONDS);
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
            var cookies = context.Request.Cookies;

            if (cookies != null)
            {
                foreach (var cookie in cookies)
                {
                    var article = await TryGetArticleFromCookie(cookie.Key);
                    if (article != null && int.TryParse(cookie.Value, out int quantity))
                        cartArticles.Add(article, quantity);
                }
            }

            return cartArticles;
        }

        private void SetCookie(HttpContext context, string key, string value, int? numberOfSeconds = null)
        {
            CookieOptions option = new CookieOptions();
            if (numberOfSeconds.HasValue)
                option.Expires = DateTime.Now.AddSeconds(numberOfSeconds.Value);
            context.Response.Cookies.Append(key, value, option);
        }

        public int GetQuantityInCart(HttpContext context, Guid articleId)
        {
            var quantity = context.Request.Cookies[articleId.ToString()];
            return
                (quantity != null && int.TryParse(quantity, out int result))
                ? result : 0;
        }

        public int RemoveFromCart(HttpContext context, Guid id)
        {
            var existing = context.Request.Cookies[id.ToString()];
            if (existing != null && int.TryParse(existing, out int numberOfItems))
            {
                if (numberOfItems > 1)
                {
                    SetCookie(context, id.ToString(), (numberOfItems - 1).ToString(), WEEK_TIME_SECONDS);
                    return numberOfItems - 1;
                }
                else
                    context.Response.Cookies.Delete(id.ToString());
            }
            return 0;
        }
    }
}
