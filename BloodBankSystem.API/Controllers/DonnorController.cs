using BloodBankSystem.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankSystem.API.Controllers
{

    [ApiController]
    [Route("api/donors")]
    public class DonnorController : ControllerBase
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
        public IActionResult Post(CreateDonnorInputModel model)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateDonnorInputModel model)
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
