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

namespace ArticleShop.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesApiController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesApiController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetAllAsync() =>
            await _categoryRepository.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<Category?> GetByIdAsync(Guid id) =>
            await _categoryRepository.GetByIdAsync(id);

        [HttpPost]
        public async Task<Category?> PostAsync([FromBody] Category category)
        {
            category.Id = Guid.Empty;
            await _categoryRepository.Add(category);
            return await GetByIdAsync(category.Id);
        }


        [HttpPut]
        public async Task<Category?> Put([FromBody] Category category)
        {
            await _categoryRepository.Update(category);
            return await GetByIdAsync(category.Id);
        }
            
        [HttpPatch("{id}")]
        public async Task<StatusCodeResult> Patch(Guid id, [FromBody] JsonPatchDocument<Category> patch)
        {
            Category? category = await GetByIdAsync(id);
            if (category != null)
            {
                patch.ApplyTo(category);
                await _categoryRepository.Update(category);
                return Ok();
            }
            return NotFound();
        }


        [HttpDelete("{id}")]
        public async Task Delete(Guid id) => await _categoryRepository.Remove(id);
    }
}
