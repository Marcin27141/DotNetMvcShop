using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopRazor.Database;
using ShopRazor.Models.Database;
using ShopRazor.Repositories.ArticleRepository;
using ShopRazor.Repositories.CategoryRepository;
using ShopRazor.Repositories.ImageRepository;

namespace ShopRazor.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IImageRepository _imageRepository;
        private readonly ICategoryRepository _categoryRepository;

        public string DefaultImagePath { get; set; }
        public IEnumerable<SelectListItem> AvailableCategories { get; set; }
        [BindProperty]
        public Guid SelectedCategoryId { get; set; }
        [BindProperty]
        public IFormFile? FormFile { get; set; }

        public EditModel(IArticleRepository articleRepository,
            IImageRepository imageRepository,
            ICategoryRepository categoryRepository
            )
        {
            _articleRepository = articleRepository;
            _imageRepository = imageRepository;
            _categoryRepository = categoryRepository;
        }

        [BindProperty]
        public Article Article { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();

            var article = await _articleRepository.GetByIdAsync(id.Value);
            if (article == null)
                return NotFound();

            Article = article;
            AvailableCategories = _categoryRepository.GetSelectListCategories();
            DefaultImagePath = _imageRepository.GetDefaultImagePath();

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newImagePath = await _imageRepository.GetWebImagePath(FormFile);
            if (Article.ImagePath != newImagePath)
            {
                _imageRepository.HandleLooseImage(Article.ImagePath);
                Article.ImagePath = newImagePath;
            }

            await _articleRepository.Update(Article);
            return RedirectToPage($"Details", new { id = Article.Id });
        }
    }
}
