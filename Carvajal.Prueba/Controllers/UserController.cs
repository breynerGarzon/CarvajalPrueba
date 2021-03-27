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

        [HttpPost("[action]")]
        public IActionResult Create([FromBody] UserView newUser)
        {
            try
            {
                return Ok(this._userBusinessServices.Add(newUser));

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("[action]")]
        public IActionResult Update([FromBody] UserView newUser)
        {
            return Ok(this._userBusinessServices.Update(newUser));
        }

        [HttpGet("[action]/{userId}")]
        public IActionResult User(string userId)
        {
            return Ok(this._userBusinessServices.Get(userId));
        }

        [HttpGet("[action]")]
        public IActionResult Users()
        {
            return Ok(this._userBusinessServices.Get(""));
        }

        [HttpDelete("[action]/{userId}")]
        public IActionResult Delete(string userId)
        {
            return Ok(this._userBusinessServices.Delete(userId));
        }
    }
}