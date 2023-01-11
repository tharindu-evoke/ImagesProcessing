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

        public IActionResult Process(ImgSet dataset)
        {
            if (ModelState.IsValid)
            {
                string imageName = "";
                //try
                //{
                //foreach (ImgSet imageSet in dataset)
                //{
                        foreach (IFormFile img in dataset.ImageFile)
                        {
                            imageName = Convert.ToString(_imageRepository.SaveImage(img));

                            //if(imageSet.Eff1 == true)
                            //{
                            //    bool s1 = _imageRepository.Effect01(img, imageName);
                            //}

                            //if (imageSet.Eff2 == true)
                            //{
                            //    bool s1 = _imageRepository.Effect02(img, imageName);
                            //}

                            //if (imageSet.Eff3 == true)
                            //{
                            //    bool s1 = _imageRepository.Effect03(img, imageName);
                            //}
                        }
                    //}
                    if(imageName == "")
                    {
                        return RedirectToAction("Privacy", "Home");
                    }
                    return RedirectToAction("Index", "Home");
                //}
                //catch (Exception e)
                //{
                //    return RedirectToAction("Index");
                //}
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
