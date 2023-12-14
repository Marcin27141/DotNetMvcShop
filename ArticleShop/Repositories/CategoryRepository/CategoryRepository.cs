using ArticleShop.Models.Database;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Runtime.CompilerServices;

namespace ArticleShop.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopDbContext _context;

        public CategoryRepository(ShopDbContext context)
        {
            this._context = context;
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
