using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

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

        public void Effect01(IFormFile imageFile, string name)
        {
            string path = Path.Combine(_hostEnvironment.ContentRootPath, "Resources\\Eff1", name);

            Bitmap bitmap = BitmapImage(imageFile);
            bitmap = resize(bitmap, 100);
            SaveBitmap(bitmap, path);
        }

        public void Effect02(IFormFile imageFile, string name)
        {

        }

        public void Effect03(IFormFile imageFile, string name)
        {

        }

        private Bitmap BitmapImage(IFormFile imageFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                imageFile.CopyToAsync(memoryStream);
                using (Bitmap img = (Bitmap)System.Drawing.Image.FromStream(memoryStream))
                {
                    return img;
                }
            }
        }

        private void SaveBitmap(Bitmap image, string path) {
            image.Save("flower.jpg", ImageFormat.Jpeg);

            //using (var memoryStream = new MemoryStream(returns))
            //{
            //    using(FileStream file = new FileStream(path, FileMode.Create))
            //    {
            //        memoryStream.WriteTo(file);
            //    }
            //}
            //source.Save(path, ImageFormat.Jpeg);
        }

        private Bitmap resize(Bitmap img, int size)
        {
            
            return img;
        }

        private bool blur()
        {
            return false;
        }

        private bool grayscale()
        {
            return false;
        }
    }
}
