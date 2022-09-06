namespace ImagesProcessing.Models
{
    public class Image
    {
        public List<IFormFile> ImgFile { get; set; }
        public bool Eff1 { get; set; }
        public bool Eff2 { get; set; }
        public bool Eff3 { get; set; }
        public double Radious { get; set; }
    }
}
