namespace ImagesProcessing.Repositories
{
    public interface IImageRepository
    {
        string SaveImage(IFormFile imageFile);

        void Effect01(IFormFile imageFile, string name);

        void Effect02(IFormFile imageFile, string name);

        void Effect03(IFormFile imageFile, string name);
    }
}
