namespace DotnetList5Task2.Models.Shop
{
    public class Article
    {
        public Guid Id {  get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateOnly ExpiryDate { get; set; }
        public IEnumerable<ArticleCategory> Categories { get; set; }   
    }
}
