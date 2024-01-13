using ArticleShop.Models.Database;

namespace ArticleShop.Models
{
    public record CartArticle(Article Article, int Quantity);
}
