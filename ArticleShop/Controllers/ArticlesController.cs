using ArticleShop.Models;
using ArticleShop.Models.Database;
using ArticleShop.Repositories.ArticleRepository;
using ArticleShop.Repositories.CategoryRepository;
using ArticleShop.Repositories.ImageRepository;
using Microsoft.AspNetCore.Mvc;

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
            var article = await _articleRepository.GetByIdAsync(id);
            return article is null ? NotFound() : View(article);

        }

        public ActionResult Create()
        {
            return View(new FormArticle(new Article(), _imageRepository.GetDefaultImagePath())
            {
                AvailableCategories = _categoryRepository.GetSelectListCategories()
        });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] FormArticle article)
        {
            article.Id = Guid.NewGuid();
            article.ImagePath = await _imageRepository.GetWebImagePath(article.FormFile);

            await _articleRepository.Add(article);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var article = await _articleRepository.GetByIdAsync(id);
            return article is null ? NotFound() :
                View(new FormArticle(article, _imageRepository.GetDefaultImagePath())
                {
                    AvailableCategories = _categoryRepository.GetSelectListCategories()
                });
        }

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

        public async Task<ActionResult> Delete(Guid id)
        {
            var article = await _articleRepository.GetByIdAsync(id);
            return article is null ? NotFound() : View(article);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, IFormCollection collection)
        {
            var toDelete = await _articleRepository.GetByIdAsync(id);
            if (toDelete != null)
                await _articleRepository.Remove(toDelete);

            return RedirectToAction(nameof(Index));
        }
    }
}
