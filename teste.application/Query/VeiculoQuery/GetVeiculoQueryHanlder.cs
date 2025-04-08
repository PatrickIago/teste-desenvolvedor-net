using MediatR;
using teste.application.Contract;
using teste.application.ViewModels;

namespace teste.application.Query.VeiculoQuery;
public record GetVeiculoQuery() : IRequest<IEnumerable<VeiculoViewModel>>;

public class GetVeiculoQueryHandler : IRequestHandler<GetVeiculoQuery, IEnumerable<VeiculoViewModel>>
{
    private readonly IVeiculoRepository _veiculoRepository;

    public GetVeiculoQueryHandler(IVeiculoRepository veiculoRepository)
    {
        _veiculoRepository = veiculoRepository;
    }

    public async Task<IEnumerable<VeiculoViewModel>> Handle(GetVeiculoQuery request, CancellationToken cancellationToken)
    {
        var veiculos = await _veiculoRepository.Get();

        return veiculos.Select(veiculo =>
            new VeiculoViewModel(
                veiculo.Id,
                veiculo.Nome,
                veiculo.Modelo,
                veiculo.LinhaId
            )
        ).ToList();
    }
}
