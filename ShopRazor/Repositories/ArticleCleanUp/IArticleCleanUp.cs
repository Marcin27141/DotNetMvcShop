using ShopRazor.Database;

namespace ShopRazor.Repositories.ArticleCleanUp
{
    public interface IArticleCleanUp
    {
        Task HandleDeletedArticleImage(string imagePath);
        Task HandleCategoryDeleted(Category toBeDeleted, Category? mostGeneral);
    }
}
