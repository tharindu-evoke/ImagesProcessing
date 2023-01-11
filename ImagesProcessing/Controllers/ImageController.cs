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
        private readonly IImageRepository _imageRepository;

        public ImageController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [HttpPost]
        public async Task<ActionResult<List<string>>> ConvertImages([FromForm]Image images)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string imageName = "";
                    foreach (var img in images.ImgFile)
                    {
                        imageName = Convert.ToString(_imageRepository.SaveImage(img));
                        if(images.Eff1 == true)
                        {
                            _imageRepository.Effect01(imageName);
                        }

                        if (images.Eff2 == true)
                        {
                            _imageRepository.Effect02(imageName);
                        }

                        if (images.Eff3 == true)
                        {
                            _imageRepository.Effect03(imageName);
                        }
                    }
                    return Ok(imageName);                    
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
