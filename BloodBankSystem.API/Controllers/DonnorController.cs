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

        /// <summary>
        /// Obtém todos os doadores cadastrados no sistema.
        /// </summary>
        /// <param name="search">Termo de busca para filtrar doadores (opcional)</param>
        /// <returns>Lista de todos os doadores cadastrados</returns>
        /// <response code="200">Retorna a lista de doadores</response>
        [HttpGet]
        public async Task<IActionResult> Get(string search = "")
        {
            var query = new GetAllDonorsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Obtém um doador específico por meio de um ID.
        /// </summary>
        /// <param name="id">ID único do doador</param>
        /// <returns>Dados do doador solicitado</returns>
        /// <response code="200">Retorna os dados do doador</response>
        /// <response code="400">Doador não encontrado ou dados inválidos</response>
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

        /// <summary>
        /// Cria um novo doador no sistema.
        /// </summary>
        /// <param name="command">Dados do doador a ser criado</param>
        /// <returns>ID do doador criado</returns>
        /// <response code="201">Doador criado com sucesso</response>
        /// <response code="400">Dados inválidos fornecidos</response>
        [HttpPost]
        public async Task<IActionResult> Post(CreateDonorCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        /// <summary>
        /// Atualiza os dados de um doador existente.
        /// </summary>
        /// <param name="id">ID único do doador a ser atualizado</param>
        /// <param name="command">Novos dados do doador</param>
        /// <returns>Confirmação da atualização</returns>
        /// <response code="204">Doador atualizado com sucesso</response>
        /// <response code="400">Doador não encontrado ou dados inválidos</response>
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

        /// <summary>
        /// Remove um doador do sistema.
        /// </summary>
        /// <param name="id">ID único do doador a ser removido</param>
        /// <returns>Confirmação da remoção</returns>
        /// <response code="204">Doador removido com sucesso</response>
        /// <response code="400">Doador não encontrado ou não pode ser removido</response>
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