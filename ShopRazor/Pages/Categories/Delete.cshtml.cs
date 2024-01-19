using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopRazor.Database;
using ShopRazor.Models.Database;
using ShopRazor.Repositories.CategoryRepository;

namespace ShopRazor.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteModel(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
                return NotFound();

            var category = await _categoryRepository.GetByIdAsync(id.Value);

            if (category == null) return NotFound();

            Category = category;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null) return NotFound();

            var category = await _categoryRepository.GetByIdAsync(id.Value);
            if (category != null)
            {
                Category = category;
                await _categoryRepository.RemoveSafe(Category.Id);
            }

            return RedirectToPage("./Index");
        }
    }
}
