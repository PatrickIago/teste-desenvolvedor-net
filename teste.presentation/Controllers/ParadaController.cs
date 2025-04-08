using Microsoft.AspNetCore.Mvc;
using MediatR;
using teste.application.Command.ParadaCommand;
using teste.application.Query.ParadaQuery;
using teste.application.ViewModels;
namespace teste.api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ParadaController : ControllerBase
{
    private readonly IMediator _mediator;

    public ParadaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Adiciona uma nova parada")]
    public async Task<ActionResult<ParadaViewModel>> CreateParada([FromBody] CreateParadaCommand command)
    {
        var createdParada = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetParadaById), new { id = createdParada.Id }, createdParada);
    }

    [HttpDelete("Remove uma parada por um id especifico")]
    public async Task<IActionResult> DeleteParada(long id)
    {
        var result = await _mediator.Send(new DeleteParadaCommand(id));
        if (!result)
        {
            return NotFound($"Parada com ID {id} não encontrada.");
        }
        return NoContent();
    }

    [HttpGet("Retorna uma parada por um id especifico")]
    public async Task<ActionResult<ParadaViewModel>> GetParadaById(long id)
    {
        var parada = await _mediator.Send(new GetParadaByIdQuery(id));
        if (parada == null)
        {
            return NotFound($"Parada com ID {id} não encontrada.");
        }
        return Ok(parada);
    }

    [HttpGet("Retorna a lista de todas as paradas")]
    public async Task<ActionResult<IEnumerable<ParadaViewModel>>> GetParadas()
    {
        var paradas = await _mediator.Send(new GetParadaQuery());
        return Ok(paradas);
    }

    [HttpPut("Atualiza uma parada por um id especifico")]
    public async Task<ActionResult<ParadaViewModel>> UpdateParada(long id, [FromBody] UpdateParadaCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("ID fornecido não coincide com o ID da parada.");
        }

        try
        {
            var updatedParada = await _mediator.Send(command);
            return Ok(updatedParada);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}