using ArticleShop.Models;

namespace ArticleShop.Repositories.PaymentRepository
{
    public interface IPaymentRepository
    {
        List<PaymentMethod> GetPaymentMethods();
    }
}
