using ArticleShop.Models.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArticleShop.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ShopDbContext _context;

        public CategoriesController(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        public async Task<ActionResult> Details(Guid id)
        {
            return View(await _context.Categories.FindAsync(id));
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
            _context.Add(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: CategoriesController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            return View(await _context.Categories.FindAsync(id));
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
            _context.Update(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id });
        }

        // GET: CategoriesController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            return View(await _context.Categories.FindAsync(id));
        }

        // POST: CategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, IFormCollection collection)
        {
            _context.Remove<Category>(await _context.Categories.FindAsync(id));
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
