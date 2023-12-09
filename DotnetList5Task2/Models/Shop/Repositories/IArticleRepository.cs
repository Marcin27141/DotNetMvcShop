namespace DotnetList5Task2.Models.Shop.Repositories
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetAll();
        Article? GetById(Guid id);
        bool AddArticle(Article article);
        bool UpdateArticle(Article article);
        bool DeleteArticle(Guid id);
    }
}
