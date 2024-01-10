using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopRazor.Database;
using ShopRazor.Models.Database;
using ShopRazor.Repositories.ArticleCleanUp;

namespace ShopRazor.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private const string MOST_GENERAL_CATEGORY = "Others";
        private readonly ShopDbContext _context;
        private readonly IArticleCleanUp _articleCleanUp;

        public CategoryRepository(
            ShopDbContext context,
            IArticleCleanUp articleCleanUp)
        {
            _context = context;
            _articleCleanUp = articleCleanUp;
        }
        public async Task Add(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public IEnumerable<SelectListItem> GetSelectListCategories()
        {
            return _context.Categories.Select(cat => new SelectListItem() { Text = cat.Name, Value = cat.Id.ToString() }).OrderBy(cat => cat.Text);
        }

        public async Task<bool> Remove(Guid id)
        {
            var toRemove = await GetByIdAsync(id);
            if (toRemove != null)
            {
                var mostGeneralCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Name.Equals(MOST_GENERAL_CATEGORY));
                await _articleCleanUp.HandleCategoryDeleted(toRemove, mostGeneralCategory);

                await Remove(toRemove);
                return true;
            }
            return false;
        }

        public async Task Remove(Category category)
        {
            _context.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Category category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
