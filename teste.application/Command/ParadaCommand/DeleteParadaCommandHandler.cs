using MediatR;
using teste.application.Contract;

namespace teste.application.Command.ParadaCommand;
public record DeleteParadaCommand(long Id) : IRequest<bool>;

public class DeleteParadaCommandHandler : IRequestHandler<DeleteParadaCommand, bool>
{
    private readonly IParadaRepository _repo;

    public DeleteParadaCommandHandler(IParadaRepository repo)
    {
        _repo = repo;
    }

    public async Task<bool> Handle(DeleteParadaCommand request, CancellationToken cancellationToken)
    {
        // Busca a parada pelo ID
        var parada = await _repo.Get(request.Id);

        if (parada == null)
        {
            return false;
        }

        await _repo.Delete(request.Id);
        return true;
    }
}
