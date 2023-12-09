
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotnetList5Task2.Models.Shop
{
    public class ArticleCategory
    {
        private readonly static List<string> _categories = new List<string>()
        {
            "Food",
            "Board Game",
            "Computer Game",
            "Book",
            "Furniture",
            "Music",
            "School",
            "Animals"
        };

        public static List<string> GetCategories() => _categories;
        public static IEnumerable<SelectListItem> GetSelectableCategories()
        {
            return _categories.Select(cat => new SelectListItem() { Text = cat, Value = cat });
        }
    }
}