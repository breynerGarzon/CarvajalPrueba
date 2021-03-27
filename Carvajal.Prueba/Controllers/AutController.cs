using Carvajal.Prueba.Business.Interface;
using Carvajal.Prueba.Model.View;
using Microsoft.AspNetCore.Mvc;

namespace Carvajal.Prueba.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutController : ControllerBase
    {
        private readonly ILoginBusinessServices _loginBusiness;
        public AutController(ILoginBusinessServices loginBusiness)
        {
            this._loginBusiness = loginBusiness;
        }

        [HttpPost("[action]")]
        public IActionResult LogIn([FromBody] LoginView dataLog)
        {
            try
            {
                return Ok(this._loginBusiness.LogIn(dataLog));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}