﻿using Levva.Newbies.Coins.Business.Dtos;
using Levva.Newbies.Coins.Business.Interfaces;
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
        [AllowAnonymous]
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
        [AllowAnonymous]
        public ActionResult<List<TransactionDto>> GetAll([FromQuery] string? search, int pageSize, int pageNumber) {
            return _service.GetAll(search, pageSize, pageNumber);
        }

        [HttpPut]
        public IActionResult Update(TransactionDto transaction) {
            _service.Update(transaction);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> Delete(Guid id) {
            var result = await _service.Delete(id);

            if(result.hasError) {
                return BadRequest(result);
            }

            return Ok();
        }
    }


}