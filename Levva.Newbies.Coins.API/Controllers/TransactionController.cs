using Levva.Newbies.Coins.Business.Dtos;
using Levva.Newbies.Coins.Business.Interfaces;
using Levva.Newbies.Coins.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Levva.Newbies.Coins.Controllers {
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase {

        private readonly ITransactionService _service;

        public TransactionController(ITransactionService service) {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<TransactionDto>> Create(TransactionDto transaction) {
            var result = await _service.Create(transaction);

            if(result.hasError) {
                return BadRequest(result);
            }
            return Created("", result);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<TransactionDto> Get(Guid id) {
           return _service.Get(id);
        }

        [HttpGet("{pageSize:int}/{pageNumber:int}")]
        public async Task<ActionResult<TransactionResult>> GetAll([FromQuery] string? search, int pageSize, int pageNumber) {
            var result = await _service.GetAll(search, pageSize, pageNumber);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(TransactionDto transaction) {
            _service.Update(transaction);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id) {
            var result = await _service.Delete(id);

            if(result.hasError) {
                return BadRequest(result);
            }

            return Ok();
        }
    }


}
