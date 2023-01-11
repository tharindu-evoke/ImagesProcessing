namespace ImagesProcessing.Models
{
    public class ImgSet
    {
        public List<IFormFile> ImageFile { get; set; } 
        public bool Eff1 { get; set; } = false;
        public bool Eff2 { get; set; } = false;
        public bool Eff3 { get; set; } = false;
        public double Radius { get; set; } = 0;
        public double Size { get; set; } = 0;
    }
}
