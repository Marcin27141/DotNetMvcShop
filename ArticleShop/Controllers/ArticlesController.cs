using ArticleShop.Models;
using ArticleShop.Models.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ArticleShop.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ShopDbContext _context;

        public ArticlesController(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Articles.ToListAsync());
        }

        public async Task<ActionResult> Details(Guid id)
        {
            return View(await _context.Articles.FindAsync(id));
        }

        public ActionResult Create()
        {
            return View(new ArticleWithAllCategories()
            {
                Article = new Article(),
                AvailableCategories = GetSelectableCategories()
            });
        }

        private IEnumerable<SelectListItem> GetSelectableCategories()
        {
            return _context.Categories.Select(cat => new SelectListItem() { Text = cat.Name, Value = cat.Id.ToString() });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            Article article = new Article
            {
                Id = Guid.NewGuid(),
                Name = collection["Article.Name"],
                Price = Convert.ToDecimal(collection["Article.Price"]),
                ExpiryDate = DateOnly.Parse(collection["Article.ExpiryDate"]),
                CategoryId = Guid.Parse(collection["Article.CategoryId"])
            };
            _context.Add(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            return View(new ArticleWithAllCategories()
            {
                Article = await _context.Articles.FindAsync(id),
                AvailableCategories = GetSelectableCategories()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, IFormCollection collection)
        {
            Article article = new Article
            {
                Id = id,
                Name = collection["Article.Name"],
                Price = Convert.ToDecimal(collection["Article.Price"]),
                ExpiryDate = DateOnly.Parse(collection["Article.ExpiryDate"]),
                CategoryId = Guid.Parse(collection["Article.CategoryId"])
            };
            _context.Update(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id });
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            return View(await _context.Articles.FindAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, IFormCollection collection)
        {
            _context.Remove<Article>(await _context.Articles.FindAsync(id));
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
