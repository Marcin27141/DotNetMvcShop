using ArticleShop.Models.Database;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArticleShop.Models
{
    public class ArticleWithAllCategories
    {
        public Article Article { get; set; }
        public IEnumerable<SelectListItem> AvailableCategories { get; set; }
    }
}
