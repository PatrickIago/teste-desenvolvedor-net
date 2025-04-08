using MediatR;
using teste.application.Contract;
using teste.application.ViewModels;

namespace teste.application.Query.VeiculoQuery;

public record GetVeiculoByIdQuery(long Id) : IRequest<VeiculoViewModel>;

public class GetVeiculoByIdQueryHandler : IRequestHandler<GetVeiculoByIdQuery, VeiculoViewModel>
{
    private readonly IVeiculoRepository _veiculoRepository;

    public GetVeiculoByIdQueryHandler(IVeiculoRepository veiculoRepository)
    {
        _veiculoRepository = veiculoRepository;
    }

    public async Task<VeiculoViewModel> Handle(GetVeiculoByIdQuery request, CancellationToken cancellationToken)
    {
        var veiculo = await _veiculoRepository.Get(request.Id);

        if (veiculo == null)
        {
            return null;
        }

        return new VeiculoViewModel(
            veiculo.Id,
            veiculo.Nome,
            veiculo.Modelo,
            veiculo.LinhaId
        );
    }
}
