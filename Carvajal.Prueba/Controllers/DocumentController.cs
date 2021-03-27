using Carvajal.Prueba.Business.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Carvajal.Prueba.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentTypeBusinessServices _documentTypeBusiness;
        public DocumentController(IDocumentTypeBusinessServices documentTypeBusiness)
        {
            this._documentTypeBusiness = documentTypeBusiness;
        }

        [HttpGet("[action]")]
        public IActionResult Documents()
        {
            return Ok(this._documentTypeBusiness.Get(""));
        }
    }
}