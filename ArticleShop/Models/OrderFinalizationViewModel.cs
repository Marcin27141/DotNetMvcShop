using System.ComponentModel.DataAnnotations;
using static ArticleShop.Models.CartViewModel;

namespace ArticleShop.Models
{
    public class OrderFinalizationViewModel
    {
        public IEnumerable<CartArticle> OrderedArticles { get; set; }
        public DeliveryViewModel DeliveryInfo { get; set; }
        [Required]
        public string? PaymentOption { get; set; }
    }
}
