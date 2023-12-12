namespace DotnetList5Task2.Models.Shop
{
    public class ArticlesList
    {
        public IEnumerable<Article> Articles { get; set; }
        public decimal PricesSum { get; set; }
    }
}
