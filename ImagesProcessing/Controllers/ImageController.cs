using ImagesProcessing.Models;
using ImagesProcessing.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ImagesProcessing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ImageRepository _imageRepository;

        public ImageController(ImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Image>> ConvertImages([FromForm]Image images)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //foreach(var imageSet in images)
                    //{
                        foreach (var img in images.ImgFile)
                        {
                            string imageName = Convert.ToString(_imageRepository.SaveImage(img));

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

                    return Ok();
                }
                catch(Exception e)
                {
                    return BadRequest(e);
                }
            }
            else
            {
                return BadRequest("Validation Faild!");
            }
        }
    }
}
