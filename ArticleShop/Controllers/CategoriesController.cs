using ArticleShop.Models.Database;
using ArticleShop.Repositories.CategoryRepository;
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
            return View(await _categoryRepository.GetByIdAsync(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            Category category = new Category()
            {
                Id = Guid.NewGuid(),
                Name = collection["Name"]
            };
            await _categoryRepository.Add(category);
            return RedirectToAction(nameof(Index));
        }

        // GET: CategoriesController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            return View(await _categoryRepository.GetByIdAsync(id));
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, IFormCollection collection)
        {
            Category category = new Category()
            {
                Id = id,
                Name = collection["Name"]
            };
            await _categoryRepository.Update(category);
            return RedirectToAction(nameof(Details), new { id });
        }

        // GET: CategoriesController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            return View(await _categoryRepository.GetByIdAsync(id));
        }

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
