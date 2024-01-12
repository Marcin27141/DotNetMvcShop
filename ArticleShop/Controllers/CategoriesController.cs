using ArticleShop.Models.Database;
using ArticleShop.Repositories.CategoryRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArticleShop.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _categoryRepository.GetAllAsync());
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return category is null ? NotFound() : View(category);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] Category category)
        {
            category.Id = Guid.NewGuid();
            await _categoryRepository.Add(category);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        // GET: CategoriesController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return category is null ? NotFound() : View(category);
        }

        [Authorize(Roles = "Admin")]
        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, [FromForm] Category category)
        {
            category.Id = id;
            await _categoryRepository.Update(category);
            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize(Roles = "Admin")]
        // GET: CategoriesController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return category is null ? NotFound() : View(category);
        }

        [Authorize(Roles = "Admin")]
        // POST: CategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, IFormCollection collection)
        {
            await _categoryRepository.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
