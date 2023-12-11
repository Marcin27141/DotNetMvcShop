
namespace DotnetList5Task2.Models.Shop.Repositories
{
    public class ArticleDictionaryRepository : IArticleRepository
    {
        private static readonly Guid[] _initialGuids = Enumerable.Range(0, 4).Select(_ => Guid.NewGuid()).ToArray();
        private Dictionary<Guid, Article> _articles = new()
        {
            { _initialGuids[0], new Article()
            {
                Id = _initialGuids[0],
                Name = "Chocolate bar",
                Price = 2.34M,
                ExpiryDate = new DateOnly(2023, 12, 20),
                Categories = new List<string>() { "Food" }
            } },
            { _initialGuids[1], new Article()
            {
                Id = Guid.NewGuid(),
                Name = "Bird cage",
                Price = 47.29M,
                ExpiryDate = new DateOnly(2033, 12, 20),
                Categories = new List<string>() { "Animals", "Furniture" }
            } },
            { _initialGuids[2], new Article()
            {
                Id = Guid.NewGuid(),
                Name = "Flute coursebook",
                Price = 10.00M,
                ExpiryDate = new DateOnly(2034, 7, 7),
                Categories = new List<string>() { "Music", "School", "Book" }
            } },
            { _initialGuids[3], new Article()
            {
                Id = Guid.NewGuid(),
                Name = "Gloomhaven",
                Price = 80.99M,
                ExpiryDate = new DateOnly(2043, 1, 1),
                Categories = new List<string>() { "Board Game", "Computer Game" }
            } },
        };
        public bool AddArticle(Article article)
        {
            if (_articles.ContainsKey(article.Id))
                return false;

            _articles.Add(article.Id, article);
            return true;
        }

        public bool DeleteArticle(Guid id) => _articles.Remove(id);

        public IEnumerable<Article> GetAll() => _articles.Values.ToList();

        public Article? GetById(Guid id)
        {
            _articles.TryGetValue(id, out var article);
            return article;
        }

        public bool UpdateArticle(Article article)
        {
            if (_articles.ContainsKey(article.Id))
            {
                _articles[article.Id] = article;
                return true;
            }

            return false;
        }
    }
}
