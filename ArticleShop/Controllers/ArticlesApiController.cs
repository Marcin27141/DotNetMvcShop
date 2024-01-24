using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArticleShop.Models.Database;
using Microsoft.AspNetCore.Cors;
using ArticleShop.Repositories.CategoryRepository;
using NuGet.Protocol.Core.Types;
using Microsoft.AspNetCore.JsonPatch;
using ArticleShop.Repositories.ArticleRepository;
using ArticleShop.Repositories.ImageRepository;
using ArticleShop.Models;

namespace ArticleShop.Controllers
{
    [Route("api/articles")]
    [ApiController]
    public class ArticlesApiController : Controller
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IImageRepository _imageRepository;

        public ArticlesApiController(
            IArticleRepository articleRepository,
            ICategoryRepository categoryRepository,
            IImageRepository imageRepository
            )
        {
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;
            _imageRepository = imageRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Article>> GetAllAsync() =>
            await _articleRepository.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<Article?> GetByIdAsync(Guid id) =>
            await _articleRepository.GetByIdAsync(id);

        [HttpPost]
        public async Task<Article?> PostAsync([FromBody] ApiFormArticle newArticle)
        {
            var article = new Article()
            {
                Id = Guid.NewGuid(),
                Name = newArticle.Name,
                Price = newArticle.Price,
                ImagePath = _imageRepository.GetDefaultImagePath(),
                ExpiryDate = newArticle.ExpiryDate,
                CategoryId = newArticle.CategoryId
            };
            await _articleRepository.Add(article);
            return await GetByIdAsync(article.Id);
        }


        [HttpPut]
        public async Task<Article?> Put([FromBody] ApiFormArticle updatedArticle)
        {
            var article = new Article()
            {
                Id = updatedArticle.Id,
                Name = updatedArticle.Name,
                Price = updatedArticle.Price,
                ImagePath = _imageRepository.GetDefaultImagePath(),
                ExpiryDate = updatedArticle.ExpiryDate,
                CategoryId = updatedArticle.CategoryId
            };
            await _articleRepository.Update(article);
            return await GetByIdAsync(article.Id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id) => await _articleRepository.Remove(id);
    }
}
