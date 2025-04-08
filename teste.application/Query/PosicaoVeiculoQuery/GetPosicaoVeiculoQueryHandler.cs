using MediatR;
using teste.application.Contract;
using teste.application.ViewModels;
namespace teste.application.Query.PosicaoVeiculoQuery
{
    public record GetPosicaoVeiculoQuery() : IRequest<IEnumerable<PosicaoVeiculoViewModel>>;

    public class GetPosicaoVeiculoQueryHandler : IRequestHandler<GetPosicaoVeiculoQuery, IEnumerable<PosicaoVeiculoViewModel>>
    {
        private readonly IPosicaoVeiculoRepository _posicaoVeiculoRepository;

        public GetPosicaoVeiculoQueryHandler(IPosicaoVeiculoRepository posicaoVeiculoRepository)
        {
            _posicaoVeiculoRepository = posicaoVeiculoRepository;
        }

        public async Task<IEnumerable<PosicaoVeiculoViewModel>> Handle(GetPosicaoVeiculoQuery request, CancellationToken cancellationToken)
        {
            var posicoes = await _posicaoVeiculoRepository.Get();

            return posicoes.Select(posicao =>
                new PosicaoVeiculoViewModel(
                    posicao.Id,
                    posicao.Latitude,
                    posicao.Longitude,
                    posicao.VeiculoId,
                    new VeiculoViewModel(
                        posicao.Veiculo.Id,
                        posicao.Veiculo.Nome,
                        posicao.Veiculo.Modelo,
                        posicao.Veiculo.LinhaId
                    )
                )).ToList();
        }
    }
}
