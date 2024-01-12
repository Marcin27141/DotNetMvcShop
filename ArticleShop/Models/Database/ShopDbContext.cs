using ArticleShop.Repositories.ImageRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ArticleShop.Models.Database
{
    public class ShopDbContext: IdentityDbContext
    {
        private readonly IServiceProvider _serviceProvider;

        public ShopDbContext(DbContextOptions<ShopDbContext> options, IServiceProvider serviceProvider) : base(options)
        {
            _serviceProvider = serviceProvider;
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            var imageRepository = _serviceProvider.GetRequiredService<IImageRepository>();
            modelBuilder.Seed(imageRepository);
            modelBuilder.Entity<Article>().Navigation(a => a.Category).AutoInclude();
        }
    }

    
}
