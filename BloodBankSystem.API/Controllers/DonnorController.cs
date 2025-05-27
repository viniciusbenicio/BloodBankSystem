using BloodBankSystem.Application.Models;
using BloodBankSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankSystem.API.Controllers
{

    [ApiController]
    [Route("api/donors")]
    public class DonnorController : ControllerBase
    {
        private readonly IDonorService _donorService;
        public DonnorController(IDonorService donorService)
        {
            _donorService = donorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _donorService.GetAll();

            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _donorService.GetById(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }


        [HttpPost]
        public IActionResult Post(CreateDonnorInputModel model)
        {
            var result = _donorService.Insert(model);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
        }

        [HttpPost("{id}")]
        public IActionResult PostAddress(CreateDonorAddressInputModel model)
        {
            //var result = _donorService.Insert(model);

            //return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateDonnorInputModel model)
        {
            var result = _donorService.Update(model);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var result = _donorService.Delete(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }


    }

}
