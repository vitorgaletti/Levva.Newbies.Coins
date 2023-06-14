using Levva.Newbies.Coins.Business.Dtos;
using Levva.Newbies.Coins.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Levva.Newbies.Coins.Controllers {
    [Route("api")]
    [ApiController]
    public class LoginController : ControllerBase {

        private readonly IUserService _service;

        public LoginController(IUserService service) {
            _service = service;
        }

        [HttpPost("auth")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginDto>> Login(LoginDto? loginDto) {
            var result = await _service.Login(loginDto);

            if(result.hasError) {
                return Unauthorized(result);
            }

            return Ok(result);
        }
    }
}
