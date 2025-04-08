using MediatR;
using teste.application.Contract;
using teste.application.ViewModels;
using teste.domain.Entities;

namespace teste.application.Command.VeiculoCommand;

public record CreateVeiculoCommand(string Nome, string Modelo, long LinhaId) : IRequest<VeiculoViewModel>;

public class CreateVeiculoCommandHandler : IRequestHandler<CreateVeiculoCommand, VeiculoViewModel>
{
    private readonly IVeiculoRepository _repo;
    private readonly ILinhaRepository _linhaRepo;

    public CreateVeiculoCommandHandler(IVeiculoRepository repo, ILinhaRepository linhaRepo)
    {
        _repo = repo;
        _linhaRepo = linhaRepo;
    }

    public async Task<VeiculoViewModel> Handle(CreateVeiculoCommand request, CancellationToken cancellationToken)
    {
        var linha = await _linhaRepo.Get(request.LinhaId);
        if (linha == null)
        {
            throw new KeyNotFoundException($"Linha com ID {request.LinhaId} não encontrada.");
        }

        var veiculoEntity = new VeiculoEntity
        {
            Nome = request.Nome,
            Modelo = request.Modelo,
            LinhaId = request.LinhaId
        };

        var createdVeiculo = await _repo.Create(veiculoEntity);

        return new VeiculoViewModel(
            createdVeiculo.Id,
            createdVeiculo.Nome,
            createdVeiculo.Modelo,
            createdVeiculo.LinhaId
        );
    }
}