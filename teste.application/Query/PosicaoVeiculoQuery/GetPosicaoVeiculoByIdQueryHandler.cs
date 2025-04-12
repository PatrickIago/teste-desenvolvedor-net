using MediatR;
using teste.application.Contract;
using teste.application.ViewModels;

namespace teste.application.Query.PosicaoVeiculoQuery;

public record GetPosicaoVeiculoByIdQuery(int Id) : IRequest<PosicaoVeiculoViewModel>;

public class GetPosicaoVeiculoByIdQueryHandler : IRequestHandler<GetPosicaoVeiculoByIdQuery, PosicaoVeiculoViewModel>
{
    private readonly IPosicaoVeiculoRepository _posicaoVeiculoRepository;

    public GetPosicaoVeiculoByIdQueryHandler(IPosicaoVeiculoRepository posicaoVeiculoRepository)
    {
        _posicaoVeiculoRepository = posicaoVeiculoRepository;
    }

    async Task<PosicaoVeiculoViewModel> IRequestHandler<GetPosicaoVeiculoByIdQuery, PosicaoVeiculoViewModel>.Handle(GetPosicaoVeiculoByIdQuery request, CancellationToken cancellationToken)
    {
        var posicao = await _posicaoVeiculoRepository.Get(request.Id);

        if (posicao == null)
        {
            return null;
        }

        return new PosicaoVeiculoViewModel(
            posicao.Id,
            posicao.Latitude,
            posicao.Longitude,
            posicao.VeiculoId
        );
    }
}
