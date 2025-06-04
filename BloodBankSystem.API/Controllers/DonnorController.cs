using BloodBankSystem.Application.Models;
using BloodBankSystem.Application.Queries.Donor.GetAllDonor;
using BloodBankSystem.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankSystem.API.Controllers
{

    [ApiController]
    [Route("api/donors")]
    public class DonnorController : ControllerBase
    {
        private readonly IDonorService _donorService;
        private readonly IMediator _mediator;
        public DonnorController(IDonorService donorService, IMediator mediator)
        {
            _donorService = donorService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //var result = _donorService.GetAll();

            var query = new GetAllDonorsQuery();

            var result = await _mediator.Send(query);

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
