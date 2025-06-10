using BloodBankSystem.Application.Commands.BloodStock.CreateBloodStock;
using BloodBankSystem.Application.Commands.BloodStock.DeleteBloodStock;
using BloodBankSystem.Application.Commands.BloodStock.UpdateBloodStock;
using BloodBankSystem.Application.Queries.BloodStocks.GetByIdBloodStocks;
using BloodBankSystem.Application.Queries.Donation.GetAllDonation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankSystem.Application.Controllers
{
    [ApiController]
    [Route("api/bloodStocks")]
    public class BloodStockController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BloodStockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllBloodStocksQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetByIdBloodStocksQuery(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Post(CreateBloodStockCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateBloodStockCommand command)
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
            var result = await _mediator.Send(new DeleteBloodStockCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}