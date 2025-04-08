using MediatR;
using teste.application.Contract;

namespace teste.application.Command.LinhaCommand;
public record DeleteLinhaCommand(long id) : IRequest<bool>;

public class DeleteLinhaCommandHandler : IRequestHandler<DeleteLinhaCommand, bool>
{
    private readonly ILinhaRepository _repo;
    public DeleteLinhaCommandHandler(ILinhaRepository repo)
    {
        _repo = repo;
    }
    public async Task<bool> Handle(DeleteLinhaCommand request, CancellationToken cancellationToken)
    {
        var linha = await _repo.Get(request.id);
        if (linha == null)
        {
            return false;
        }

        await _repo.Delete(request.id);
        return true;
    }
}
