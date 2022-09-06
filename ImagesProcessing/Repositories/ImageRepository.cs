using Microsoft.Extensions.Hosting;

namespace ImagesProcessing.Repositories
{
    public class ImageRepository: IImageRepository
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public ImageRepository(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public async Task<string> SaveImage(IFormFile imageFile)
        {
            //try
            //{
                string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
                imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
                var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Resources/Upload", imageName);
                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }
                return imageName;
            //}
            //catch (Exception e)
            //{
            //    return "Null";
            //}
        }

        public bool Effect01(IFormFile image, string name)
        {
            return true;

            try
            {
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Effect02(IFormFile image, string name)
        {
            return true;

            try
            {
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Effect03(IFormFile image, string name)
        {
            return true;

            try
            {
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
