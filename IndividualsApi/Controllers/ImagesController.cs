using System.Threading.Tasks;
using IndividualsApi.Data;
using IndividualsApi.Data.Interfaces;
using IndividualsApi.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IndividualsApi.Controllers
{
    [Route("api/individuals/{id:int}/images")]
    [ApiController]
    public class ImagesController : Controller
    {
        private readonly IImageHandler _imageHandler;
        private readonly IIndividualsRepository _repository;
        private readonly IImageWriter _imageWriter;

        public ImagesController(IImageHandler imageHandler,
                                IIndividualsRepository repository,
                                IImageWriter imageWriter)
        {
            _imageHandler = imageHandler;
            _repository = repository;
            _imageWriter = imageWriter;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file, int id)
        {
            var individual = await _repository.GetIndividualAsync(id);

            if (!string.IsNullOrEmpty(individual.Image))
            {
                _imageWriter.DeleteImage(individual.Image);
            }

            var newImageLocation = await _imageWriter.UploadImage(file);

            individual.Image = newImageLocation;

            if (await _repository.SaveChangesAsync())
            {
                return Ok();
            }

            return BadRequest();
        }
    }

}
