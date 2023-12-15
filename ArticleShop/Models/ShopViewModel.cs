using ArticleShop.Models.Database;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArticleShop.Models
{
    public class ShopViewModel
    {
        public IEnumerable<Article> Articles { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public Guid? SelectedCategory { get; set; }

        public ShopViewModel(IEnumerable<Article> articles, IEnumerable<SelectListItem> categories)
        {
            Articles = articles;
            Categories = categories;
        }
    }
}
