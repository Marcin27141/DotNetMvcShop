using ArticleShop.Models.Database;

namespace ArticleShop.Repositories.ArticleRepository
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetAllAsync();
        Task<Article?> GetByIdAsync(Guid id);
        Task<Article?> GetNextById(Guid id);
        Task<Article?> GetPreviousById(Guid id);
        Task Add(Article article);
        Task<bool> Remove(Guid id);
        Task Remove(Article article);
        Task Update(Article article);

    }
}
