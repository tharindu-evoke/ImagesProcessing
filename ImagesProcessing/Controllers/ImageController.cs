using ImagesProcessing.Models;
using ImagesProcessing.Repositories;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace ImagesProcessing.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageRepository _imageRepository;

        public ImageController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Process([FromForm]ImgSet dataset)
        {
            //if (ModelState.IsValid)
            //{
                string imageName = "";
                try
                {
                    foreach (IFormFile img in dataset.ImageFile)
                    {        
                        imageName = Convert.ToString(_imageRepository.SaveImage(img));

                        if (dataset.Eff1 == true)
                        {
                            bool s1 = _imageRepository.Effect01(img, imageName);
                        }

                    //if (imageSet.Eff2 == true)
                    //{
                    //    bool s1 = _imageRepository.Effect02(img, imageName);
                    //}

                    //if (imageSet.Eff3 == true)
                    //{
                    //    bool s1 = _imageRepository.Effect03(img, imageName);
                    //}
                }

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception e)
                {
                    return RedirectToAction("Index");
                }
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Home");
            //}
        }
    }
}
