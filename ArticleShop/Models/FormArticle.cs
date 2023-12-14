using ArticleShop.Models.Database;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArticleShop.Models
{
    public class FormArticle
    {
        public Article Article { get; set; }
        public IFormFile? FormFile { get; set; }
        public string DefaultImageSrc { get; set; }
        public IEnumerable<SelectListItem> AvailableCategories { get; set; }
    }
}
