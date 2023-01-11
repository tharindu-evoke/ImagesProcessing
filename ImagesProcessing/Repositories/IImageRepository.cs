namespace ImagesProcessing.Repositories
{
    public interface IImageRepository
    {
        string SaveImage(IFormFile imageFile);
    }
}
