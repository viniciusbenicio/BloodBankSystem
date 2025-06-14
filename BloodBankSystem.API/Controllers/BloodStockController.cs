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

        /// <summary>
        /// Obtém todo o estoque de sangue disponível no banco de sangue.
        /// </summary>
        /// <returns>Lista completa do estoque de sangue por tipo sanguíneo</returns>
        /// <response code="200">Retorna a lista do estoque de sangue</response>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllBloodStocksQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Obtém informações específicas de um estoque de sangue por ID.
        /// </summary>
        /// <param name="id">ID único do registro de estoque de sangue</param>
        /// <returns>Dados do estoque de sangue solicitado</returns>
        /// <response code="200">Retorna os dados do estoque de sangue</response>
        /// <response code="400">Estoque não encontrado ou dados inválidos</response>
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

        /// <summary>
        /// Cria um novo registro de estoque de sangue ou adiciona unidades ao estoque existente.
        /// </summary>
        /// <param name="command">Dados do estoque de sangue a ser criado</param>
        /// <returns>ID do registro de estoque criado</returns>
        /// <response code="201">Estoque de sangue criado com sucesso</response>
        /// <response code="400">Dados inválidos fornecidos</response>
        [HttpPost]
        public async Task<IActionResult> Post(CreateBloodStockCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        /// <summary>
        /// Atualiza as informações de um registro de estoque de sangue existente.
        /// </summary>
        /// <param name="id">ID único do registro de estoque a ser atualizado</param>
        /// <param name="command">Novos dados do estoque de sangue</param>
        /// <returns>Confirmação da atualização</returns>
        /// <response code="204">Estoque de sangue atualizado com sucesso</response>
        /// <response code="400">Estoque não encontrado ou dados inválidos</response>
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

        /// <summary>
        /// Remove um registro de estoque de sangue do sistema.
        /// </summary>
        /// <param name="id">ID único do registro de estoque a ser removido</param>
        /// <returns>Confirmação da remoção</returns>
        /// <response code="204">Registro de estoque removido com sucesso</response>
        /// <response code="400">Estoque não encontrado ou não pode ser removido</response>
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