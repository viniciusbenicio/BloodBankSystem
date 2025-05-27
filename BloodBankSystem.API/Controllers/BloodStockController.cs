using BloodBankSystem.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankSystem.Application.Controllers
{
    [ApiController]
    [Route("api/bloodStocks")]
    public class BloodStockController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById()
        {
            return Ok();

        }


        [HttpPost]
        public IActionResult Post(CreateBloodStockInputModel model)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateBloodStockInputModel model)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            return NoContent();
        }
    }
}
