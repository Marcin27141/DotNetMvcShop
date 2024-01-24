using ArticleShop.Models.Database;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace ArticleShop.Models
{
    public class ApiFormArticle
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public DateOnly ExpiryDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);
        public Guid CategoryId { get; set; }
    }
}
