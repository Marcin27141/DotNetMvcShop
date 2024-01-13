using ArticleShop.Models;

namespace ArticleShop.Repositories.PaymentRepository
{
    public class PaymentRepository : IPaymentRepository
    {
        private static readonly List<PaymentMethod> _paymentMethods =
        [
            new PaymentMethod(Guid.NewGuid(), "Credit", "https://i.imgur.com/28akQFX.jpg"),
            new PaymentMethod(Guid.NewGuid(), "Paypal", "https://i.imgur.com/5QFsx7K.jpg"),
            new PaymentMethod(Guid.NewGuid(), "Blik", "https://prowly-uploads.s3.eu-west-1.amazonaws.com/uploads/landing_page/template_background/87888/dd1f56953d31387f206bb0d1e41c9300.jpg"),
        ];
        public List<PaymentMethod> GetPaymentMethods() => _paymentMethods;
    }
}
