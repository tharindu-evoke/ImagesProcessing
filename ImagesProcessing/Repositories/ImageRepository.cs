using System.Drawing;
//using System.Drawing.Drawing2D;
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

        public void Effect01(string name)
        {
            string getPath = Path.Combine(_hostEnvironment.ContentRootPath, "Resources\\Row", name);
            string setPath = Path.Combine(_hostEnvironment.ContentRootPath, "Resources\\Eff1", name);
            resize(getPath, setPath, 100);

            //Blur
            string path = Path.Combine(_hostEnvironment.ContentRootPath, "Resources\\Eff1", name);
            blur(path, path, 2);
        }

        public void Effect02(string name)
        {
            string getPath = Path.Combine(_hostEnvironment.ContentRootPath, "Resources\\Row", name);
            string setPath = Path.Combine(_hostEnvironment.ContentRootPath, "Resources\\Eff2", name);
            resize(getPath, setPath, 100);
        }

        public void Effect03(string name)
        {
            string getPath = Path.Combine(_hostEnvironment.ContentRootPath, "Resources\\Row", name);
            string setPath = Path.Combine(_hostEnvironment.ContentRootPath, "Resources\\Eff3", name);
            resize(getPath, setPath, 100);

            //Blur
            string path = Path.Combine(_hostEnvironment.ContentRootPath, "Resources\\Eff3", name);
            blur(path, path, 5);

            //Grayscale
            path = Path.Combine(_hostEnvironment.ContentRootPath, "Resources\\Eff3", name);
            grayscale(path, path);
        }


        private void resize(string getPath, string setPath, int size)
        {
            try
            {
                using (Image image = Image.Load(getPath))
                {
                    image.Mutate(x => x.Resize(size, size));
                    image.Save(setPath);
                }
            } 
            catch(Exception e) { }
        }

        private void blur(string getPath, string setPath, int blur)
        {
            try { 
                using (Image image = Image.Load(getPath))
                {
                    image.Mutate(x => x.GaussianBlur(blur));
                    image.Save(setPath);
                }
            }
            catch (Exception e) { }
        }

        private void grayscale(string getPath, string setPath)
        {
            try { 
                using (Image image = Image.Load(getPath))
                {
                    image.Mutate(x => x.Grayscale());
                    image.Save(setPath);
                }
            }
            catch (Exception e) { }
        }
    }
}
