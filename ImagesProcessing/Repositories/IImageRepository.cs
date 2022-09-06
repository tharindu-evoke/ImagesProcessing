namespace ImagesProcessing.Repositories
{
    public interface IImageRepository
    {
        Task<string> SaveImage(IFormFile imageFile);

        bool Effect01(IFormFile image, string name);

        bool Effect02(IFormFile image, string name);

        bool Effect03(IFormFile image, string name);
    }
}
