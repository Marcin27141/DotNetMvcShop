using ShopRazor.Database;

namespace ShopRazor.Repositories.CartRepository
{
    public interface ICartRepository
    {
        Task<Dictionary<Article, int>> GetArticlesInCartAsync(HttpContext context);
        int AddToCart(HttpContext context, Guid articleId);
        int GetQuantityInCart(HttpContext context, Guid articleId);
        int RemoveFromCart(HttpContext context, Guid id);

        void RemoveAllFromCart(HttpContext context, Guid id);
    }
}
