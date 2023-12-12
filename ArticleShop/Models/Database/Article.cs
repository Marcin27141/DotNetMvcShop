using System.ComponentModel;

namespace ArticleShop.Models.Database
{
    public class Article
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }

        [DisplayName("Expiry Date")]
        public DateOnly ExpiryDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);
        public Category Category { get; set; }
    }
}
