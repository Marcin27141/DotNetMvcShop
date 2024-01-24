using ArticleShop.Repositories.ImageRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ArticleShop.Models.Database
{
    public static class DbContextExtensions
    {
        private static Category OthersCategory = new Category() { Id = Guid.NewGuid(), Name = "Others" };
        private static List<Category> _initialCategories = new List<Category>() {
            OthersCategory,
            new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Food"
            }, new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Board Game"
            },
            new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Computer Game"
            },
            new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Book"
            },
            new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Furniture"
            },
            new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Music"
            },
            new Category()
            {
                Id = Guid.NewGuid(),
                Name = "School"
            },
            new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Animals"
            }};

        public static void Seed(this ModelBuilder modelBuilder, IImageRepository imageRepository)
        {
            SeedCategories(modelBuilder);
            SeedArticles(modelBuilder, imageRepository);
        }

        private static void SeedArticles(ModelBuilder modelBuilder, IImageRepository imageRepository)
        {
            modelBuilder.Entity<Article>().HasData(
                new Article()
                {
                    Id = Guid.NewGuid(),
                    Name = "Chocolate bar",
                    Price = 2.34M,
                    ImagePath = imageRepository.GetDefaultImagePath(),
                    ExpiryDate = new DateOnly(2023, 12, 20),
                    CategoryId = TryGetCategoryId("Food"),
                },
                new Article()
                {
                    Id = Guid.NewGuid(),
                    Name = "Spaghetti",
                    Price = 9.99M,
                    ImagePath = imageRepository.GetDefaultImagePath(),
                    ExpiryDate = new DateOnly(2024, 1, 1),
                    CategoryId = TryGetCategoryId("Food"),
                },
                new Article()
                {
                    Id = Guid.NewGuid(),
                    Name = "Bird cage",
                    Price = 47.29M,
                    ImagePath = imageRepository.GetDefaultImagePath(),
                    ExpiryDate = new DateOnly(2033, 12, 20),
                    CategoryId = TryGetCategoryId("Animals")
                },
                new Article()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dog collar",
                    Price = 29.10M,
                    ImagePath = imageRepository.GetDefaultImagePath(),
                    ExpiryDate = new DateOnly(2033, 12, 20),
                    CategoryId = TryGetCategoryId("Animals")
                },
                new Article()
                {
                    Id = Guid.NewGuid(),
                    Name = "Leash",
                    Price = 12.00M,
                    ImagePath = imageRepository.GetDefaultImagePath(),
                    ExpiryDate = new DateOnly(2026, 5, 20),
                    CategoryId = TryGetCategoryId("Animals")
                },
                new Article()
                {
                    Id = Guid.NewGuid(),
                    Name = "Flute coursebook",
                    Price = 10.00M,
                    ImagePath = imageRepository.GetDefaultImagePath(),
                    ExpiryDate = new DateOnly(2034, 7, 7),
                    CategoryId = TryGetCategoryId("Music")
                },
                new Article()
                {
                    Id = Guid.NewGuid(),
                    Name = "Guitar",
                    Price = 100.00M,
                    ImagePath = imageRepository.GetDefaultImagePath(),
                    ExpiryDate = new DateOnly(2027, 1, 1),
                    CategoryId = TryGetCategoryId("Music")
                },
                new Article()
                {
                    Id = Guid.NewGuid(),
                    Name = "Trumpet",
                    Price = 27.00M,
                    ImagePath = imageRepository.GetDefaultImagePath(),
                    ExpiryDate = new DateOnly(2027, 1, 1),
                    CategoryId = TryGetCategoryId("Music")
                },
                new Article()
                {
                    Id = Guid.NewGuid(),
                    Name = "Gloomhaven",
                    Price = 80.99M,
                    ImagePath = imageRepository.GetDefaultImagePath(),
                    ExpiryDate = new DateOnly(2043, 1, 1),
                    CategoryId = TryGetCategoryId("Board Game")
                },
                new Article()
                {
                    Id = Guid.NewGuid(),
                    Name = "Ark Nova",
                    Price = 75.28M,
                    ImagePath = imageRepository.GetDefaultImagePath(),
                    ExpiryDate = new DateOnly(2033, 1, 1),
                    CategoryId = TryGetCategoryId("Board Game")
                },
                new Article()
                {
                    Id = Guid.NewGuid(),
                    Name = "Wingspan",
                    Price = 42.68M,
                    ImagePath = imageRepository.GetDefaultImagePath(),
                    ExpiryDate = new DateOnly(2029, 1, 1),
                    CategoryId = TryGetCategoryId("Board Game")
                });
        }

        private static Guid TryGetCategoryId(string name)
        {
            var resultCategory = _initialCategories.Find(c => c.Name == name) ?? OthersCategory;
            return resultCategory.Id;
        }

        private static void SeedCategories(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(_initialCategories);
        }
    }
}
