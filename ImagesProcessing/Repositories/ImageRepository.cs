using System.Security.Cryptography;
using System.Text;

namespace ImagesProcessing.Repositories
{
    public class ImageRepository: IImageRepository
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public ImageRepository(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public string SaveImage(IFormFile imageFile)
        {
            try
            {
                using (SHA1 sha1Hash = SHA1.Create())
                {
                    byte[] sourceBytes = Encoding.UTF8.GetBytes(DateTime.Now.ToString("yymmssfff"));
                    byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
                    string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

                    string imageName = hash + Path.GetExtension(imageFile.FileName);
                    var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Resources/Row", imageName);
                    using (var fileStream = new FileStream(imagePath, FileMode.Create))
                    {
                        imageFile.CopyToAsync(fileStream);
                    }

                    return imageName;
                }
            }
            catch (Exception e)
            {
                return "Null";
            }
        }

        public bool Effect01(IFormFile imageFile, string name)
        {

            return false;
        }
    }
}
