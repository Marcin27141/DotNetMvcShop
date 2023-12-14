
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Runtime.CompilerServices;

namespace ArticleShop.Repositories.ImageRepository
{
    public class ImageRepository : IImageRepository
    {
        private const string UPLOADS_DIRECTORY_NAME = "upload";
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ImageRepository(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<string> GetWebImagePath(IFormFile file)
        {
            return (file != null && file.Length > 0) ?
                await CreateOrReplaceImage(file) :
                GetDefaultImagePath();
        }
        private async Task<string> CreateOrReplaceImage(IFormFile file)
        {
            string filePath = GenerateFilepath();

            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return GetRelativeImagePath(filePath);
        }

        private string GetRelativeImagePath(string filePath)
        {
            var normalizedPath = filePath.ToString().Replace("\\", "/");
            return normalizedPath.Substring(normalizedPath.IndexOf('/' + UPLOADS_DIRECTORY_NAME));
        }

        public void HandleLooseImage(string imagePath)
        {
            if (IsAnUploadedFile(imagePath)) {
                var fullPath = Path.Combine(_hostingEnvironment.WebRootPath, imagePath.TrimStart('/'));
                if (File.Exists(fullPath))
                    File.Delete(fullPath);
            }
        }

        public string GetDefaultImagePath() => "/image/no_image.jpg";

        private bool IsAnUploadedFile(string imagePath) => imagePath.Contains(UPLOADS_DIRECTORY_NAME);
        private string GenerateFilepath() => Path.Combine(GetUploadsPath(), Guid.NewGuid().ToString() + ".jpg");
        private string GetUploadsPath() => Path.Combine(_hostingEnvironment.WebRootPath, UPLOADS_DIRECTORY_NAME);

        
    }
}
