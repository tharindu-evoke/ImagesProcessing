namespace ImagesProcessing.Repositories
{
    public interface IImageRepository
    {
        string SaveImage(IFormFile imageFile);

        void Effect01(string name);

        void Effect02(string name);

        void Effect03(string name);
    }
}
