using ArticleShop.Models.Database;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ArticleShop.Repositories.CartRepository
{
    public interface ICartRepository
    {
        Task<Dictionary<Article, int>> GetArticlesInCartAsync(HttpContext context);
        int AddToCart(HttpContext context, Guid articleId);
        int GetQuantityInCart(HttpContext context, Guid articleId);
        int RemoveFromCart(HttpContext context, Guid id);

        void RemoveAllFromCart(HttpContext context, Guid id);
        void RemoveAllFromCart(HttpContext context);
    }
}
