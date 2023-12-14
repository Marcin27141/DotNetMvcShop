﻿using ArticleShop.Models.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Runtime.CompilerServices;

namespace ArticleShop.Repositories.ArticleRepository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ShopDbContext _context;

        public ArticleRepository(ShopDbContext context)
        {
            this._context = context;
        }
        public async Task Add(Article article)
        {
            _context.Add(article);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task<Article?> GetByIdAsync(Guid id)
        {
            return await _context.Articles.FindAsync(id);
        }

        public async Task<bool> Remove(Guid id)
        {
            var toRemove = await GetByIdAsync(id);
            if (toRemove != null)
            {
                await Remove(toRemove);
                return true;
            }
            return false;
        }

        public async Task Remove(Article article)
        {
            _context.Remove(article);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Article article)
        {
            _context.Update(article);
            await _context.SaveChangesAsync();
        }
    }
}