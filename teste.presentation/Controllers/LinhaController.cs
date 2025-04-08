using Microsoft.AspNetCore.Mvc;
using MediatR;
using teste.application.Command.LinhaCommand;
using teste.application.Query.LinhaQuery;
using teste.application.ViewModels;

namespace teste.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LinhaController : ControllerBase
{
    private readonly IMediator _mediator;

    public LinhaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Adiciona uma nova linha")]
    public async Task<ActionResult<LinhaViewModel>> CreateLinha([FromBody] CreateLinhaCommand command)
    {
        var createdLinha = await _mediator.Send(command);
        return Ok(createdLinha);
    }

    [HttpDelete("Remove uma linha especifica")]
    public async Task<IActionResult> DeleteLinha(long id)
    {
        var result = await _mediator.Send(new DeleteLinhaCommand(id));
        if (!result)
        {
            return NotFound($"Linha com ID {id} não encontrada.");
        }
        return NoContent();
    }

    [HttpGet("Retorna uma linha especifica")]
    public async Task<ActionResult<LinhaViewModel>> GetLinhaById(long id)
    {
        var linha = await _mediator.Send(new GetLinhaByIdQuery(id));
        if (linha == null)
        {
            return NotFound($"Linha com ID {id} não encontrada.");
        }
        return Ok(linha);
    }

    [HttpGet("Retorna uma lista com todas as linhas")]
    public async Task<ActionResult<IEnumerable<LinhaViewModel>>> GetLinhas()
    {
        var linhas = await _mediator.Send(new GetLinhaQuery());
        return Ok(linhas);
    }

    [HttpPut("Atualiza os dados de uma linha especifica")]
    public async Task<ActionResult<LinhaViewModel>> UpdateLinha(long id, [FromBody] UpdateLinhaCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("ID fornecido não coincide com o ID da linha.");
        }

        try
        {
            var updatedLinha = await _mediator.Send(command);
            return Ok(updatedLinha);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
