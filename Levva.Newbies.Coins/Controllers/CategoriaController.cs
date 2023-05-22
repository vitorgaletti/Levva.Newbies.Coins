using Levva.Newbies.Coins.Business.Dtos;
using Levva.Newbies.Coins.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Levva.Newbies.Coins.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase {

        private readonly ICategoriaService _service;

        public CategoriaController(ICategoriaService service) {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create(CategoriaDto categoria) {
            _service.Create(categoria);
            return Created("", categoria);
        }

        [HttpGet]
        public ActionResult<CategoriaDto> Get(int id) {
            return _service.Get(id);
        }

        [HttpGet("list")]
        public ActionResult<List<CategoriaDto>> GetAll() {
            return _service.GetAll();
        }

        [HttpPut]
        public IActionResult Update(CategoriaDto categoria) {
            _service.Update(categoria);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id) {
            _service.Delete(id);
            return Ok();
        }
    }
}
