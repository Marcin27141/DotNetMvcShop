using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace DotnetList5Task2.Models.Shop
{
    public class CreateArticle
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        [DisplayName("Expiry Date")]
        public DateOnly ExpiryDate { get; set; }
        public IEnumerable<string> Categories { get; set; } = new List<string>();
        public IEnumerable<SelectListItem> AvailableCategories { get; set; } = new List<SelectListItem>();
    }
}
