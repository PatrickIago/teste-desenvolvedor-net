using MediatR;
using teste.application.Contract;

namespace teste.application.Command.PosicaoVeiculoCommand;

public record DeletePosicaoVeiculoCommand(int Id) : IRequest<bool>;

public class DeletePosicaoVeiculoCommandHandler : IRequestHandler<DeletePosicaoVeiculoCommand, bool>
{
    private readonly IPosicaoVeiculoRepository _repo;

    public DeletePosicaoVeiculoCommandHandler(IPosicaoVeiculoRepository repo)
    {
        _repo = repo;
    }

    public async Task<bool> Handle(DeletePosicaoVeiculoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repo.Get(request.Id);
        if (entity == null)
            return false;

        return await _repo.Delete(request.Id);
    }
}
