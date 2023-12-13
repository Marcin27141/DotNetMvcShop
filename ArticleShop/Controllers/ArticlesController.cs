using ArticleShop.Models;
using ArticleShop.Models.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;

namespace ArticleShop.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ShopDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ArticlesController(ShopDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Articles.ToListAsync());
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var article = await _context.Articles.FindAsync(id);
            return View(article);
        }

        public ActionResult Create()
        {
            return View(new FormArticle()
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
            var newImagePath = await WriteSelectedFile(collection);

            Article article = new Article
            {
                Id = Guid.NewGuid(),
                Name = collection["Article.Name"],
                Price = Convert.ToDecimal(collection["Article.Price"]),
                ExpiryDate = DateOnly.Parse(collection["Article.ExpiryDate"]),
                CategoryId = Guid.Parse(collection["Article.CategoryId"]),
                ImagePath = newImagePath
            };
            _context.Add(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            return View(new FormArticle()
            {
                Article = await _context.Articles.FindAsync(id),
                AvailableCategories = GetSelectableCategories()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, IFormCollection collection)
        {
            var newImagePath = await WriteSelectedFile(collection);

            Article article = new Article
            {
                Id = id,
                Name = collection["Article.Name"],
                Price = Convert.ToDecimal(collection["Article.Price"]),
                ExpiryDate = DateOnly.Parse(collection["Article.ExpiryDate"]),
                CategoryId = Guid.Parse(collection["Article.CategoryId"]),
                ImagePath = newImagePath
            };
            _context.Update(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id });
        }

        private async Task<string> WriteSelectedFile(IFormCollection collection)
        {
            var file = collection.Files["FormFile"];
            var filePath = collection["Article.ImagePath"];
            if (file != null && file.Length > 0)
            {
                if (!filePath.Contains("upload"))
                {
                    string uploadsPath = Path.Combine(_hostingEnvironment.WebRootPath, "upload");
                    filePath = Path.Combine(uploadsPath, Guid.NewGuid().ToString() + ".jpg");
                }
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                var result = filePath.ToString().Replace("\\", "/");
                return result.Substring(result.IndexOf("/upload"));
            }
            else return "/image/no_image.jpg";
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
