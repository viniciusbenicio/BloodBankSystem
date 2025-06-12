using BloodBankSystem.Application.Commands.Donation.CreateDonation;
using BloodBankSystem.Application.Commands.Donation.DeleteDonation;
using BloodBankSystem.Application.Commands.Donation.UpdateDonation;
using BloodBankSystem.Application.Queries.Donation.GetAllDonation;
using BloodBankSystem.Application.Queries.Donation.GetByIdDonation;
using BloodBankSystem.Application.Queries.Donation.GetDonationsByDonorId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankSystem.API.Controllers
{
    [ApiController]
    [Route("api/donations")]
    public class DonationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DonationController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllDonationQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetByIdDonationQuery(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Post(CreateDonationCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateDonationCommand command)
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
            var result = await _mediator.Send(new DeleteDonationCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpGet("donor/{donorId}")]
        public async Task<IActionResult> GetDonationsByDonorId(int donorId)
        {
            var result = await _mediator.Send(new GetDonationsByDonorIdQuery(donorId));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }


            return Ok(new { success = result.IsSuccess, message = result.Message, data = result.Data });
        }

    }
}
