
namespace DotnetList5Task2.Models.Shop.Repositories
{
    public class ArticleListRepository : IArticleRepository
    {
        private List<Article> _articles = new List<Article>()
        {
            new Article()
            {
                Id = Guid.NewGuid(),
                Name = "Chocolate bar",
                Price = 2.34M,
                ExpiryDate = new DateOnly(2023, 12, 20),
                Categories = new List<string>() { "Food" }
            },
            new Article()
            {
                Id = Guid.NewGuid(),
                Name = "Bird cage",
                Price = 47.29M,
                ExpiryDate = new DateOnly(2033, 12, 20),
                Categories = new List<string>() { "Animals", "Furniture" }
            },
            new Article()
            {
                Id = Guid.NewGuid(),
                Name = "Flute coursebook",
                Price = 10.00M,
                ExpiryDate = new DateOnly(2034, 7, 7),
                Categories = new List<string>() { "Music", "School", "Book" }
            },
            new Article()
            {
                Id = Guid.NewGuid(),
                Name = "Gloomhaven",
                Price = 80.99M,
                ExpiryDate = new DateOnly(2043, 1, 1),
                Categories = new List<string>() { "Board Game", "Computer Game" }
            },
        };

        public bool AddArticle(Article article)
        {
            if (GetById(article.Id) != null)
                return false;

            _articles.Add(article);
            return true;
        }

        public bool DeleteArticle(Guid id)
        {
            var articleToRemove = GetById(id);

            if (articleToRemove != null)
            {
                _articles.Remove(articleToRemove);
                return true;
            }

            return false;
        }

        public Article? GetById(Guid id)
        {
        return _articles.FirstOrDefault(a => a.Id == id);
        }

        public bool UpdateArticle(Article article)
        {
            var existingArticleIdx = _articles.FindIndex(art => art.Id == article.Id);

            if (existingArticleIdx >= 0)
            {
                _articles[existingArticleIdx] = article;
                return true;
            }
            return false;
        }

        public IEnumerable<Article> GetAll() => _articles;
    }
}
