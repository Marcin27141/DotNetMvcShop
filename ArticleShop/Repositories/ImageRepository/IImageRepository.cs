namespace ArticleShop.Repositories.ImageRepository
{
    public interface IImageRepository
    {
        void HandleLooseImage(string imagePath);
        string GetDefaultImagePath();
        Task<string> GetWebImagePath(IFormFile file);
    }
}
