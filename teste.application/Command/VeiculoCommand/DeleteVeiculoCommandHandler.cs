using MediatR;
using teste.application.Contract;

namespace teste.application.Command.VeiculoCommand;
public record DeleteVeiculoCommand(long Id) : IRequest<bool>;

public class DeleteVeiculoCommandHandler : IRequestHandler<DeleteVeiculoCommand, bool>
{
    private readonly IVeiculoRepository _repo;

    public DeleteVeiculoCommandHandler(IVeiculoRepository repo)
    {
        _repo = repo;
    }

    public async Task<bool> Handle(DeleteVeiculoCommand request, CancellationToken cancellationToken)
    {
        var veiculo = await _repo.Get(request.Id);
        if (veiculo == null)
        {
            return false;
        }

        return await _repo.Delete(request.Id);
    }
}
