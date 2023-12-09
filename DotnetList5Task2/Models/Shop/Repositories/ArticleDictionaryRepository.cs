
namespace DotnetList5Task2.Models.Shop.Repositories
{
    public class ArticleDictionaryRepository : IArticleRepository
    {
        private Dictionary<Guid, Article> _articles = new();
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
