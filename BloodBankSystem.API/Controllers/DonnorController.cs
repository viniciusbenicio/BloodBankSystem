using BloodBankSystem.Application.Commands.Donation.DeleteDonation;
using BloodBankSystem.Application.Commands.Donor.CreateDonor;
using BloodBankSystem.Application.Commands.Donor.DeleteDonor;
using BloodBankSystem.Application.Commands.Donor.UpdateDonor;
using BloodBankSystem.Application.Queries.Donor.GetAllDonor;
using BloodBankSystem.Application.Queries.Donor.GetByIdDonor;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankSystem.API.Controllers
{

    [ApiController]
    [Route("api/donors")]
    public class DonnorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DonnorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string search = "")
        {
            var query = new GetAllDonorsQuery();

            var result = await _mediator.Send(query);

            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetByIdDonorQuery(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Post(CreateDonorCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }
       

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateDonorCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteDonorCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }


    }

}
