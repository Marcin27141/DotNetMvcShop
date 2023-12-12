﻿using Microsoft.EntityFrameworkCore;

namespace ArticleShop.Models.Database
{
    public class ShopDbContext(DbContextOptions<ShopDbContext> options) : DbContext(options)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
    }

    
}
