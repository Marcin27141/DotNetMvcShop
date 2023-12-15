using ArticleShop.Models.Database;
using ArticleShop.Repositories.ImageRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace ArticleShop.Repositories.ArticleCleanUp
{
    public class ArticleCleanUp : IArticleCleanUp
    {
        private readonly ShopDbContext _context;
        private readonly IImageRepository _imageRepository;

        public ArticleCleanUp(ShopDbContext context, IImageRepository imageRepository)
        {
            _context = context;
            _imageRepository = imageRepository;
        }
        public async Task AssignArticlesToGeneralCategory(Category toBeDeleted, Category mostGeneral)
        {
            if (toBeDeleted != mostGeneral)
            {
                await _context.Articles
                    .Where(a => a.CategoryId == toBeDeleted.Id)
                    .ForEachAsync(a => a.CategoryId = mostGeneral.Id);
                await _context.SaveChangesAsync();
            }
        }

        public async Task HandleCategoryDeleted(Category toBeDeleted, Category? mostGeneral)
        {
            if (mostGeneral != null && toBeDeleted != mostGeneral)
                await AssignArticlesToGeneralCategory(toBeDeleted, mostGeneral);
            else
                await _context.Articles.ForEachAsync(a => HandleDeletedArticleImage(a.ImagePath));
        }

        public Task HandleDeletedArticleImage(string imagePath)
        {
            _imageRepository.HandleLooseImage(imagePath);
            return Task.CompletedTask;
        }
    }
}
