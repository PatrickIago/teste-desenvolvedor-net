using Microsoft.AspNetCore.Mvc;
using MediatR;
using teste.application.Command.PosicaoVeiculoCommand;
using teste.application.Query.PosicaoVeiculoQuery;
using teste.application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace teste.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PosicaoVeiculoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PosicaoVeiculoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Adiciona uma nova posição de veículo")]
        public async Task<ActionResult<PosicaoVeiculoViewModel>> CreatePosicaoVeiculo([FromBody] CreatePosicaoVeiculoCommand command)
        {
            var createdPosicaoVeiculo = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetPosicaoVeiculoById), new { id = createdPosicaoVeiculo.Id }, createdPosicaoVeiculo);
        }

        [HttpDelete("Remove uma posição de veículo específica")]
        public async Task<IActionResult> DeletePosicaoVeiculo(int id)
        {
            var result = await _mediator.Send(new DeletePosicaoVeiculoCommand(id));
            if (!result)
            {
                return NotFound($"Posição de veículo com ID {id} não encontrada.");
            }
            return NoContent();
        }

        [HttpGet("Retorna uma posição de veículo específica")]
        public async Task<ActionResult<PosicaoVeiculoViewModel>> GetPosicaoVeiculoById(int id)
        {
            var posicaoVeiculo = await _mediator.Send(new GetPosicaoVeiculoByIdQuery(id));
            if (posicaoVeiculo == null)
            {
                return NotFound($"Posição de veículo com ID {id} não encontrada.");
            }
            return Ok(posicaoVeiculo);
        }

        [HttpGet("Retorna uma lista com todas as posições de veículos")]
        public async Task<ActionResult<IEnumerable<PosicaoVeiculoViewModel>>> GetPosicoesVeiculos()
        {
            var posicoesVeiculos = await _mediator.Send(new GetPosicaoVeiculoQuery());
            return Ok(posicoesVeiculos);
        }

        [HttpPut("Atualiza os dados de uma posição de veículo específica")]
        public async Task<ActionResult<PosicaoVeiculoViewModel>> UpdatePosicaoVeiculo(int id, [FromBody] UpdatePosicaoVeiculoCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("ID fornecido não coincide com o ID da posição de veículo.");
            }

            try
            {
                var updatedPosicaoVeiculo = await _mediator.Send(command);
                return Ok(updatedPosicaoVeiculo);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}