namespace ArticleShop.Models
{
    public class PaymentMethod(Guid id, string name, string logoUrl)
    {
        public Guid Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string LogoUrl { get; set; } = logoUrl;
    }
}
