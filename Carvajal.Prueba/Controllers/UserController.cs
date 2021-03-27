using Carvajal.Prueba.Business.Interface;
using Carvajal.Prueba.Model.View;
using Microsoft.AspNetCore.Mvc;

namespace Carvajal.Prueba.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserBusinessServices _userBusinessServices;
        public UserController(IUserBusinessServices userBusinessServices)
        {
            this._userBusinessServices = userBusinessServices;
        }

        /// <summary>
        /// Api rest para la creación he inserción de usuarios en BD.
        /// </summary> 
        [HttpPost("[action]")]
        public IActionResult Create([FromBody] UserView newUser)
        {
            try
            {
                return Ok(this._userBusinessServices.Add(newUser));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Api rest para la actualización de la información de los usuarios en BD o sistema.
        /// </summary> 
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] UserView newUser)
        {
            try
            {
                return Ok(this._userBusinessServices.Update(newUser));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Api rest para la consulta de usuarios.
        /// </summary> 
        [HttpGet("[action]")]
        public IActionResult Users()
        {
            try
            {
                return Ok(this._userBusinessServices.Get(""));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Api rest para la eliminación de usuarios, como valor de entrada se ingresa el número de documento.
        /// </summary> 
        [HttpDelete("[action]/{userId}")]
        public IActionResult Delete(string userId)
        {
            try
            {
                return Ok(this._userBusinessServices.Delete(userId));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}