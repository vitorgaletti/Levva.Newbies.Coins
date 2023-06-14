using Levva.Newbies.Coins.Business.Dtos;
using Levva.Newbies.Coins.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Levva.Newbies.Coins.Controllers {
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase {

        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service) {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Create(CategoryDto category) {
            var result = await _service.Create(category);

            if(result.hasError) {
                return BadRequest(result);
            }
            return Created("", result);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<CategoryDto> Get(Guid id) {
            return _service.Get(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetAll() {
            var categories = await _service.GetAll();
            return categories;
        }

        [HttpPut]
        public IActionResult Update(CategoryDto category) {
            _service.Update(category);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Guid id) {
            _service.Delete(id);
            return Ok();
        }
    }
}
