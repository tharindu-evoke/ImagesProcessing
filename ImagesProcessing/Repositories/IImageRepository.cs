namespace ImagesProcessing.Repositories
{
    public interface IImageRepository
    {
        string SaveImage(IFormFile imageFile);

        bool Effect01(string name);

        bool Effect02(string name);

        bool Effect03(string name);
    }
}
