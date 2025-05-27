using BloodBankSystem.Application.Models;
using BloodBankSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankSystem.Application.Controllers
{
    [ApiController]
    [Route("api/bloodStocks")]
    public class BloodStockController : ControllerBase
    {
        private readonly IBloodStockService _bloodStockService;
        public BloodStockController(IBloodStockService bloodStockService)
        {
            _bloodStockService = bloodStockService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _bloodStockService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _bloodStockService.GetById(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);

        }


        [HttpPost]
        public IActionResult Post(CreateBloodStockInputModel model)
        {
            var result = _bloodStockService.Insert(model);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateBloodStockInputModel model)
        {
            var result = _bloodStockService.Update(model);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var result = _bloodStockService.Delete(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
