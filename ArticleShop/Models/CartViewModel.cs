using ArticleShop.Models.Database;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArticleShop.Models
{
    public class CartViewModel
    {
        public IEnumerable<CartArticle> CartArticles { get; set; }

        public CartViewModel(IEnumerable<CartArticle> CartArticles)
        {
            this.CartArticles = CartArticles;
        }
    }
}
