using ShopRazor.Database;

namespace ShopRazor.Repositories.ArticleRepository
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetAllAsync();
        Task<Article?> GetByIdAsync(Guid id);
        Task Add(Article article);
        Task<bool> Remove(Guid id);
        Task Remove(Article article);
        Task Update(Article article);

    }
}
