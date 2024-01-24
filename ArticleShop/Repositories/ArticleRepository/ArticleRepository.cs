using ArticleShop.Models.Database;
using ArticleShop.Repositories.ArticleCleanUp;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Runtime.CompilerServices;

namespace ArticleShop.Repositories.ArticleRepository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ShopDbContext _context;
        private readonly IArticleCleanUp _articleCleanUp;

        public ArticleRepository(ShopDbContext context, IArticleCleanUp articleCleanUp)
        {
            _context = context;
            _articleCleanUp = articleCleanUp;
        }
        public async Task Add(Article article)
        {
            _context.Add(article);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task<Article?> GetByIdAsync(Guid id)
        {
            return await _context.Articles.FindAsync(id);
        }

        public async Task<IEnumerable<Article>> GetChunk(int chunkSize, Guid? afterId)
        {
            var articles = afterId == null ? _context.Articles : _context.Articles.Where(a => a.Id > afterId);
            return await articles.OrderBy(a => a.Id).Take(chunkSize).ToListAsync();
        }

        public Task<Article?> GetNextById(Guid id)
        {
            return _context.Articles
                .Where(a => a.Id > id)
                .OrderBy(a => a.Id)
                .FirstOrDefaultAsync();

        }

        public Task<Article?> GetPreviousById(Guid id)
        {
            return _context.Articles
                .Where(a => a.Id < id)
                .OrderByDescending(a => a.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Remove(Guid id)
        {
            var toRemove = await GetByIdAsync(id);
            if (toRemove != null)
            {
                await Remove(toRemove);
                return true;
            }
            return false;
        }

        public async Task Remove(Article article)
        {
            await _articleCleanUp.HandleDeletedArticleImage(article.ImagePath);
            _context.Remove(article);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Article article)
        {
            _context.Update(article);
            await _context.SaveChangesAsync();
        }
    }
}
