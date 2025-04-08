using MediatR;
using teste.application.Contract;
using teste.application.ViewModels;

namespace teste.application.Command.VeiculoCommand;
public record UpdateVeiculoCommand(long Id, string Nome, string Modelo, long LinhaId) : IRequest<VeiculoViewModel>;

public class UpdateVeiculoCommandHandler : IRequestHandler<UpdateVeiculoCommand, VeiculoViewModel>
{
    private readonly IVeiculoRepository _repo;
    private readonly ILinhaRepository _linhaRepo;

    public UpdateVeiculoCommandHandler(IVeiculoRepository repo, ILinhaRepository linhaRepo)
    {
        _repo = repo;
        _linhaRepo = linhaRepo;
    }

    public async Task<VeiculoViewModel> Handle(UpdateVeiculoCommand request, CancellationToken cancellationToken)
    {
        var veiculoEntity = await _repo.Get(request.Id);
        if (veiculoEntity == null)
        {
            throw new KeyNotFoundException($"Veículo com ID {request.Id} não encontrado.");
        }

        var linha = await _linhaRepo.Get(request.LinhaId);
        if (linha == null)
        {
            throw new KeyNotFoundException($"Linha com ID {request.LinhaId} não encontrada.");
        }

        veiculoEntity.Nome = request.Nome;
        veiculoEntity.Modelo = request.Modelo;
        veiculoEntity.LinhaId = request.LinhaId;

        var updatedVeiculo = await _repo.Update(veiculoEntity);

        return new VeiculoViewModel(
            updatedVeiculo.Id,
            updatedVeiculo.Nome,
            updatedVeiculo.Modelo,
            updatedVeiculo.LinhaId
        );
    }
}

