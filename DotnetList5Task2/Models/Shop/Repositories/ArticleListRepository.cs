
namespace DotnetList5Task2.Models.Shop.Repositories
{
    public class ArticleListRepository : IArticleRepository
    {
        private List<Article> _articles = new List<Article>();

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
