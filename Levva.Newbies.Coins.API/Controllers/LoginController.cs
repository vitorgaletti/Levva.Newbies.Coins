using Levva.Newbies.Coins.Business.Dtos;
using Levva.Newbies.Coins.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Levva.Newbies.Coins.Controllers {
    [Route("api")]
    [ApiController]
    public class LoginController : ControllerBase {

        private readonly IUsuarioService _service;

        public LoginController(IUsuarioService service) {
            _service = service;
        }

        [HttpPost("auth")]
        [AllowAnonymous]
        public ActionResult<LoginDto> Login(LoginDto? loginDto) {
            var login = _service.Login(loginDto);

            if(login == null) {
                return BadRequest("Usuário ou senha inválidos");
            }

            return Ok(login);
        }
    }
}
