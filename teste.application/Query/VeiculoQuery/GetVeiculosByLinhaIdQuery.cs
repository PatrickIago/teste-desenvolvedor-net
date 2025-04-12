using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using teste.application.ViewModels;
using teste.application.Contract;

namespace teste.application.Query.VeiculoQuery
{
    public record GetVeiculosByLinhaIdQuery(long LinhaId) : IRequest<IEnumerable<VeiculoViewModel>>;

    public class GetVeiculosByLinhaIdQueryHandler : IRequestHandler<GetVeiculosByLinhaIdQuery, IEnumerable<VeiculoViewModel>>
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public GetVeiculosByLinhaIdQueryHandler(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<IEnumerable<VeiculoViewModel>> Handle(GetVeiculosByLinhaIdQuery request, CancellationToken cancellationToken)
        {
            // Chama o repositório para obter os veículos associados à linha
            var veiculos = await _veiculoRepository.GetByLinhaId(request.LinhaId);
            return veiculos;
        }
    }
}