using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopRazor.Database;
using ShopRazor.Models.Database;
using ShopRazor.Repositories.ArticleRepository;
using ShopRazor.Repositories.CategoryRepository;
using ShopRazor.Repositories.ImageRepository;

namespace ShopRazor.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IImageRepository _imageRepository;
        private readonly ICategoryRepository _categoryRepository;

        public string DefaultImagePath { get; set; }
        public IEnumerable<SelectListItem> AvailableCategories { get; set; }

        [BindProperty]
        public IFormFile? FormFile { get; set; }
        [BindProperty]
        public Article Article { get; set; } = default!;

        public CreateModel(IArticleRepository articleRepository,
            IImageRepository imageRepository,
            ICategoryRepository categoryRepository
            )
        {
            _articleRepository = articleRepository;
            _imageRepository = imageRepository;
            _categoryRepository = categoryRepository;

            DefaultImagePath = _imageRepository.GetDefaultImagePath();
            AvailableCategories = _categoryRepository.GetSelectListCategories();
        }

        public IActionResult OnGet()
        {
            return Page();
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Article.ImagePath = await _imageRepository.GetWebImagePath(FormFile);
            await _articleRepository.Add(Article);

            return RedirectToPage("Details", new { id = Article.Id });
        }
    }
}
