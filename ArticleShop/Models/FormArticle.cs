using ArticleShop.Models.Database;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace ArticleShop.Models
{
    public class FormArticle : Article
    {
        public IFormFile? FormFile { get; set; }
        public string DefaultImageSrc { get; set; }
        public IEnumerable<SelectListItem> AvailableCategories { get; set; } = new List<SelectListItem>();

        public FormArticle() { }

        public FormArticle(Article article, string defaultImageSrc)
        {
            Id = article.Id;
            Name = article.Name;
            Price = article.Price;
            ImagePath = article.ImagePath;
            ExpiryDate = article.ExpiryDate;
            Category = article.Category;
            CategoryId = article.CategoryId;

            DefaultImageSrc = defaultImageSrc;
        }
    }
}
