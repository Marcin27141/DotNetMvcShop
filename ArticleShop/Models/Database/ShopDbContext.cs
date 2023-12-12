using Microsoft.EntityFrameworkCore;

namespace ArticleShop.Models.Database
{
    public class ShopDbContext: DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();
            modelBuilder.Entity<Article>().Navigation(a => a.Category).AutoInclude();

        }
    }

    
}
