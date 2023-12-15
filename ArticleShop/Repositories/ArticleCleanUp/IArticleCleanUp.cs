using ArticleShop.Models.Database;

namespace ArticleShop.Repositories.ArticleCleanUp
{
    public interface IArticleCleanUp
    {
        Task HandleDeletedArticleImage(string imagePath);
        Task HandleCategoryDeleted(Category toBeDeleted, Category? mostGeneral);
        //Task AssignArticlesToGeneralCategory(Category toBeDeleted, Category mostGeneral);
    }
}
