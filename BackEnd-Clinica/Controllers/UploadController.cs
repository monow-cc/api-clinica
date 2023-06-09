using BackEnd_Clinica.Model;
using BackEnd_Clinica.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly UploadFile _fileUploader;

        public UploadController(UploadFile fileUploader)
        {
            _fileUploader = fileUploader;
        }

        [HttpPost]
        public async Task<ActionResult<string>> UploadFile(IFormFile file)
        {

            string ImageName = await _fileUploader.SaveImage(file);

            string retorno = String.Format("{0}://{1}{2}/Archives/{3}", Request.Scheme, Request.Host, Request.PathBase, ImageName);

            return Ok(retorno);

        }
    }
}
