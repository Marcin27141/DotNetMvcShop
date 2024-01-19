using ArticleShop.Models.Database;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArticleShop.Models
{
    public class ShopViewModel
    {
        public IEnumerable<Article> Articles { get; set; }
        public Dictionary<Guid, int> ArticlesInCart { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public Guid? SelectedCategory { get; set; }

        public ShopViewModel(IEnumerable<Article> articles,
            Dictionary<Guid, int> articlesInCart,
            IEnumerable<SelectListItem> categories)
        {
            Articles = articles;
            ArticlesInCart = articlesInCart;
            Categories = categories;
        }
    }
}
