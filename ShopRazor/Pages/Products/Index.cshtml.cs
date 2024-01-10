using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShopRazor.Database;
using ShopRazor.Models.Database;
using ShopRazor.Repositories.ArticleRepository;

namespace ShopRazor.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IArticleRepository _articleRepository;

        public IndexModel(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public IEnumerable<Article> Article { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Article = await _articleRepository.GetAllAsync();
        }

        public async Task OnPostAsync(string? searchValue)
        {
            searchValue ??= "";
            var articles = await _articleRepository.GetAllAsync();
            var lowerSearch = searchValue.ToLower();
            Article = articles.Where(a => a.Name.ToLower().Contains(lowerSearch) || a.Category.Name.ToLower().Contains(lowerSearch));
        }
    }
}
