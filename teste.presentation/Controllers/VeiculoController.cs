using MediatR;
using Microsoft.AspNetCore.Mvc;
using teste.application.Command.VeiculoCommand;
using teste.application.Query.VeiculoQuery;
using teste.application.ViewModels;

namespace teste.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VeiculoController : ControllerBase
{
    private readonly IMediator _mediator;

    public VeiculoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("Retorna uma lista de todos os veiculos")]
    public async Task<ActionResult<IEnumerable<VeiculoViewModel>>> Get()
    {
        var result = await _mediator.Send(new GetVeiculoQuery());
        return Ok(result);
    }

    [HttpGet("Retorna um veiculo por um id especifico")]
    public async Task<ActionResult<VeiculoViewModel>> Get(long id)
    {
        var result = await _mediator.Send(new GetVeiculoByIdQuery(id));
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost("Adiciona um novo veiculo")]
    public async Task<ActionResult<VeiculoViewModel>> Create([FromBody] CreateVeiculoCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpPut("Atualiza os dados de um veiculo especifico")]
    public async Task<ActionResult<VeiculoViewModel>> Update(long id, [FromBody] UpdateVeiculoCommand command)
    {
        if (id != command.Id)
            return BadRequest("ID da URL diferente do corpo da requisição.");

        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("Remove um veiculo especifico")]
    public async Task<ActionResult> Delete(long id)
    {
        var result = await _mediator.Send(new DeleteVeiculoCommand(id));
        if (!result)
            return NotFound();

        return NoContent();
    }
}
