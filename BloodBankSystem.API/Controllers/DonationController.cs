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

        /// <summary>
        /// Obtém todas as doações registradas no sistema.
        /// </summary>
        /// <returns>Lista de todas as doações cadastradas</returns>
        /// <response code="200">Retorna a lista de doações</response>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllDonationQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Obtém uma doação específica por meio de um ID.
        /// </summary>
        /// <param name="id">ID único da doação</param>
        /// <returns>Dados da doação solicitada</returns>
        /// <response code="200">Retorna os dados da doação</response>
        /// <response code="400">Doação não encontrada ou dados inválidos</response>
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

        /// <summary>
        /// Registra uma nova doação no sistema.
        /// </summary>
        /// <param name="command">Dados da doação a ser registrada</param>
        /// <returns>ID da doação criada</returns>
        /// <response code="201">Doação registrada com sucesso</response>
        /// <response code="400">Dados inválidos fornecidos</response>
        [HttpPost]
        public async Task<IActionResult> Post(CreateDonationCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        /// <summary>
        /// Atualiza os dados de uma doação existente.
        /// </summary>
        /// <param name="id">ID único da doação a ser atualizada</param>
        /// <param name="command">Novos dados da doação</param>
        /// <returns>Confirmação da atualização</returns>
        /// <response code="204">Doação atualizada com sucesso</response>
        /// <response code="400">Doação não encontrada ou dados inválidos</response>
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

        /// <summary>
        /// Remove uma doação do sistema.
        /// </summary>
        /// <param name="id">ID único da doação a ser removida</param>
        /// <returns>Confirmação da remoção</returns>
        /// <response code="204">Doação removida com sucesso</response>
        /// <response code="400">Doação não encontrada ou não pode ser removida</response>
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

        /// <summary>
        /// Obtém todas as doações realizadas por um doador específico.
        /// </summary>
        /// <param name="donorId">ID único do doador</param>
        /// <returns>Lista de doações do doador especificado</returns>
        /// <response code="200">Retorna a lista de doações do doador</response>
        /// <response code="400">Doador não encontrado ou dados inválidos</response>
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