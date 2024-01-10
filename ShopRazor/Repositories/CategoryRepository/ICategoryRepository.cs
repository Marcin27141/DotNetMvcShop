using Microsoft.AspNetCore.Mvc.Rendering;
using ShopRazor.Database;

namespace ShopRazor.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        IEnumerable<SelectListItem> GetSelectListCategories();
        Task<Category?> GetByIdAsync(Guid id);
        Task Add(Category category);
        Task<bool> Remove(Guid id);
        Task Remove(Category category);
        Task Update(Category category);

    }
}
