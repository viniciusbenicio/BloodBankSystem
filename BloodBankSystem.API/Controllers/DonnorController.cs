using BloodBankSystem.API.Entities;
using BloodBankSystem.API.Entities.Persistence;
using BloodBankSystem.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankSystem.API.Controllers
{

    [ApiController]
    [Route("api/donors")]
    public class DonnorController : ControllerBase
    {
        private readonly BloodBankSystemDBContext context;
        public DonnorController(BloodBankSystemDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {

            var teste = this.context.Donors.FirstOrDefault();
            return Ok(teste);

        }

        [HttpGet("{id}")]
        public IActionResult GetById()
        {
            return Ok();
        }


        [HttpPost]
        public IActionResult Post(CreateDonnorInputModel model)
        {

            var donor = new Donor("TESTE", "", DateTime.Now, "", 1, "", "")
            {
               
            };

            this.context.Donors.Add(donor);
            this.context.SaveChanges();

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
