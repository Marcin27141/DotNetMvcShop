using ArticleShop.Models;
using ArticleShop.Models.Database;
using ArticleShop.Repositories.ArticleRepository;
using ArticleShop.Repositories.CategoryRepository;
using ArticleShop.Repositories.ImageRepository;
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
        private readonly IImageRepository _imageRepository;

        public ArticlesController(
            IArticleRepository articleRepository,
            ICategoryRepository categoryRepository,
            IImageRepository imageRepository
            )
        {
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;
            _imageRepository = imageRepository;
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
                DefaultImageSrc = _imageRepository.GetDefaultImagePath(),
                AvailableCategories = _categoryRepository.GetSelectListCategories()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection/*IFormFileCollection files, [FromForm] Article article*/)
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
                DefaultImageSrc = _imageRepository.GetDefaultImagePath(),
                AvailableCategories = _categoryRepository.GetSelectListCategories()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, IFormCollection collection)
        {
            var newImagePath = await WriteSelectedFile(collection);

            var original = await _articleRepository.GetByIdAsync(id);
            if (newImagePath != original.ImagePath)
            {
                _imageRepository.HandleLooseImage(original.ImagePath);
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
            return await _imageRepository.GetWebImagePath(file);
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
                _imageRepository.HandleLooseImage(toDelete.ImagePath);
                await _articleRepository.Remove(toDelete);
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
