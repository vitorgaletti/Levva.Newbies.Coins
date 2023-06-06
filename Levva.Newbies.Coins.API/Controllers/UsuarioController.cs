using Levva.Newbies.Coins.Business.Dtos;
using Levva.Newbies.Coins.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Levva.Newbies.Coins.Controllers {
    [Route("api")]
    [ApiController]
    public class UsuarioController : ControllerBase {

        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service) {
            _service = service;
        }

        [HttpPost("user")]
        [AllowAnonymous]
        public IActionResult Create(UsuarioDto usuario) {
            _service.Create(usuario);
            return Created("", usuario);
        }

        [HttpGet]
        public ActionResult<UsuarioDto> Get(int id) {
            return _service.Get(id);
        }

        [HttpGet("list")]
        public ActionResult<List<UsuarioDto>> GetAll() {
            return _service.GetAll();
        }

        [HttpPut]
        public IActionResult Update(UsuarioDto usuario) {
            _service.Update(usuario);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id) {
            _service.Delete(id);
            return Ok();
        }
    }
}
