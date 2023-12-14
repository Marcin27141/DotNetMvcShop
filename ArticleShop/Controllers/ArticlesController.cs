using ArticleShop.Models;
using ArticleShop.Models.Database;
using ArticleShop.Repositories.ArticleRepository;
using ArticleShop.Repositories.CategoryRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using NuGet.Packaging.Signing;

namespace ArticleShop.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ArticlesController(
            IArticleRepository articleRepository,
            ICategoryRepository categoryRepository,
            IWebHostEnvironment hostingEnvironment)
        {
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _articleRepository.GetAllAsync());
        }

        public async Task<ActionResult> Details(Guid id)
        {
            return View(await _articleRepository.GetByIdAsync(id));
        }

        public ActionResult Create()
        {
            return View(new FormArticle()
            {
                Article = new Article(),
                AvailableCategories = _categoryRepository.GetSelectListCategories()
            });
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
            await _articleRepository.Add(article);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            return View(new FormArticle()
            {
                Article = await _articleRepository.GetByIdAsync(id),
                AvailableCategories = _categoryRepository.GetSelectListCategories()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, IFormCollection collection)
        {
            var newImagePath = await WriteSelectedFile(collection);

            var original = await _articleRepository.GetByIdAsync(id);
            if (newImagePath != original.ImagePath && original.ImagePath.Contains("upload"))
            {
                DeleteWebFile(original.ImagePath);
                original.ImagePath = newImagePath;
            }
                
            original.Name = collection["Article.Name"];
            original.Price = Convert.ToDecimal(collection["Article.Price"]);
            original.ExpiryDate = DateOnly.Parse(collection["Article.ExpiryDate"]);
            original.CategoryId = Guid.Parse(collection["Article.CategoryId"]);
            

            await _articleRepository.Update(original);
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
            else return collection["DefaultImageSrc"];
        }

        private void DeleteWebFile(string filePath)
        {
            var fullPath = Path.Combine(_hostingEnvironment.WebRootPath, filePath.TrimStart('/'));
            if (System.IO.File.Exists(fullPath))
                System.IO.File.Delete(fullPath);
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            return View(await _articleRepository.GetByIdAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, IFormCollection collection)
        {
            var toDelete = await _articleRepository.GetByIdAsync(id);
            if (toDelete != null)
            {
                await _articleRepository.Remove(toDelete);
                if (toDelete.ImagePath.Contains("upload"))
                    DeleteWebFile(toDelete.ImagePath);
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
