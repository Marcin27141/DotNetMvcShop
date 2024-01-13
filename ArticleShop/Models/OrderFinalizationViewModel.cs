using System.ComponentModel.DataAnnotations;

namespace ArticleShop.Models
{
    public class OrderFinalizationViewModel(
        IEnumerable<CartArticle> articles,
        List<PaymentMethod> paymentMethods
        )
    {
        public IEnumerable<CartArticle> OrderedArticles { get; set; } = articles;
        public DeliveryViewModel DeliveryInfo { get; set; } = new();
        public List<PaymentMethod> PaymentMethods { get; set; } = paymentMethods;
        [Required]
        public Guid PaymentOption { get; set; }
    }
}
