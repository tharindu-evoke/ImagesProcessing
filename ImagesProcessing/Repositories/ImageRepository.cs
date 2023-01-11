using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Hosting;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using Image = SixLabors.ImageSharp.Image;

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
                    string hash = BitConverter.ToString(hashBytes).Replace("-",String.Empty);

                    string imageName = hash + Path.GetExtension(imageFile.FileName);
                    var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Resources/Upload", imageName);
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

        public bool Effect01(string name)
        {
            try
            {
                //Resize
                string getPath = Path.Combine(_hostEnvironment.ContentRootPath, "Resources\\Upload", name);
                string setPath = Path.Combine(_hostEnvironment.ContentRootPath, "Resources\\E1", name);
                resizeImage(getPath, setPath, 100);

                //Blur
                string path = Path.Combine(_hostEnvironment.ContentRootPath, "Resources\\E1", name);
                blurImage(path, path, 2);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Effect02(string name)
        {
            try
            {
                //Resize
                string getPath = Path.Combine(_hostEnvironment.ContentRootPath, "Resources\\Upload", name);
                string setPath = Path.Combine(_hostEnvironment.ContentRootPath, "Resources\\E2", name);
                resizeImage(getPath, setPath, 100);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Effect03(string name)
        {
            try
            {
                //Resize
                string getPath = Path.Combine(_hostEnvironment.ContentRootPath, "Resources\\Upload", name);
                string setPath = Path.Combine(_hostEnvironment.ContentRootPath, "Resources\\E3", name);
                resizeImage(getPath, setPath, 100);

                //Blur
                string path = Path.Combine(_hostEnvironment.ContentRootPath, "Resources\\E3", name);
                blurImage(path, path, 5);

                //Grayscale
                //string path = Path.Combine(_hostEnvironment.ContentRootPath, "Resources\\E3", name);s
                grayscaleImage(path, path);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private void resizeImage(string getPath, string setPath, int size){
            using (Image image = Image.Load(getPath))
            {
                image.Mutate(x => x.Resize(size, size));
                image.Save(setPath);
            }
        }

        private void blurImage(string getPath, string setPath, float blur){
            using (Image image = Image.Load(getPath))
            {
                image.Mutate(x => x.GaussianBlur(blur));
                image.Save(setPath);
            }
        }

        private void grayscaleImage(string getPath, string setPath){
            using (Image image = Image.Load(getPath))
            {
                image.Mutate(x => x.Grayscale());
                image.Save(setPath);
            }
        }
    }
}
