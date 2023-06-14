using Levva.Newbies.Coins.Business.Dtos;
using Levva.Newbies.Coins.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Levva.Newbies.Coins.Controllers {
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase {

        private readonly IUserService _service;

        public UserController(IUserService service) {
            _service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Create(UserDto user) {
            var result = await _service.Create(user);

            if (result.hasError) {
                return BadRequest(result);
            }
            return Created("", user);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<UserDto>> Get(Guid id) {
            var result = await _service.Get(id);

            if (result.hasError) {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("list")]
        public ActionResult<List<UserDto>> GetAll() {
            return _service.GetAll();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateUserDto userDto) {
            var result = await _service.Update(id, userDto);

            if(result.hasError) {
                return BadRequest(result);
            }
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(Guid id) {
            _service.Delete(id);
            return Ok();
        }
    }
}
