using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopRazor.Database;
using ShopRazor.Models.Database;
using ShopRazor.Repositories.ArticleRepository;

namespace ShopRazor.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly IArticleRepository _articleRepository;

        public DetailsModel(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public Article Article { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();

            var article = await _articleRepository.GetByIdAsync(id.Value);
            if (article == null)
                return NotFound();

            Article = article;
            return Page();
        }
    }
}
