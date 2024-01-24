using ArticleShop.Models;
using ArticleShop.Models.Database;
using ArticleShop.Repositories.ArticleRepository;
using ArticleShop.Repositories.CategoryRepository;
using ArticleShop.Repositories.ImageRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public async Task<IActionResult> Index(string? searchValue)
        {
            return View(
                searchValue == null ? await _articleRepository.GetChunk(3) : await GetFilteredArticles(searchValue)
                );
        }

        private async Task<IEnumerable<Article>> GetFilteredArticles(string searchValue)
        {
            var articles = await _articleRepository.GetAllAsync();
            var lowerSearch = searchValue.ToLower();
            return articles.Where(a => a.Name.ToLower().Contains(lowerSearch) || a.Category.Name.ToLower().Contains(lowerSearch));
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var article = await _articleRepository.GetByIdAsync(id);
            return article is null ? NotFound() : View(article);

        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View(new FormArticle(new Article(), _imageRepository.GetDefaultImagePath())
            {
                AvailableCategories = _categoryRepository.GetSelectListCategories()
        });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] FormArticle article)
        {
            article.Id = Guid.NewGuid();
            article.ImagePath = await _imageRepository.GetWebImagePath(article.FormFile);

            await _articleRepository.Add(article);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(Guid id)
        {
            var article = await _articleRepository.GetByIdAsync(id);
            return article is null ? NotFound() :
                View(new FormArticle(article, _imageRepository.GetDefaultImagePath())
                {
                    AvailableCategories = _categoryRepository.GetSelectListCategories()
                });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, [FromForm] FormArticle updatedArticle)
        {
            var newImagePath = await _imageRepository.GetWebImagePath(updatedArticle.FormFile);
            updatedArticle.Id = id;

            if (updatedArticle.ImagePath != newImagePath)
            {
                _imageRepository.HandleLooseImage(updatedArticle.ImagePath);
                updatedArticle.ImagePath = newImagePath;
            }            

            await _articleRepository.Update(updatedArticle);
            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var article = await _articleRepository.GetByIdAsync(id);
            return article is null ? NotFound() : View(article);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, IFormCollection collection)
        {
            var toDelete = await _articleRepository.GetByIdAsync(id);
            if (toDelete != null)
                await _articleRepository.Remove(toDelete);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Search(string searchValue)
        {
            return RedirectToAction(nameof(Index), new { searchValue });
        }
    }
}
