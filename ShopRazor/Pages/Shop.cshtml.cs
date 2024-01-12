using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopRazor.Database;
using ShopRazor.Repositories.ArticleRepository;
using ShopRazor.Repositories.CategoryRepository;
using System.Buffers;

namespace ShopRazor.Pages
{
    public class ShopModel : PageModel
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ICategoryRepository _categoryRepository;

        public IEnumerable<Article> Articles { get; set; }
        public IEnumerable<SelectListItem> AvailableCategories { get; set; }
        [BindProperty]
        public Guid CategoryId { get; set; }

        public ShopModel(IArticleRepository articleRepository, ICategoryRepository categoryRepository)
        {
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;
            AvailableCategories = GetCategoriesWithAllOption().Result;
        }
        public async Task OnGetAsync()
        {   
            Articles = await _articleRepository.GetAllAsync();
        }

        public async Task OnPostSearch(string searchValue)
        {
            Articles = await GetFilteredArticles(searchValue);
        }

        public async Task OnPostCategory(string categoryId)
        {
            var articles = await _articleRepository.GetAllAsync();
            Articles = categoryId.Equals("all") ? articles : articles.Where(a => a.CategoryId.ToString().Equals(categoryId));
        }

        private async Task<IEnumerable<SelectListItem>> GetCategoriesWithAllOption()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var selectableCategories = categories.Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() }).OrderBy(c => c.Text);
            var withAllOption = selectableCategories.Prepend(new SelectListItem() { Text = "All", Value = "all" });
            return withAllOption;
        }

        private async Task<IEnumerable<Article>> GetFilteredArticles(string? searchValue)
        {
            var articles = await _articleRepository.GetAllAsync();
            var lowerSearch = searchValue?.ToLower() ?? "";
            return articles.Where(a => a.Name.ToLower().Contains(lowerSearch) ||
                (a.Category?.Name.ToLower().Contains(lowerSearch) ?? true));
        }
    }
}
