using AutoMapper;
using MediatR;
using teste.application.Contract;
using teste.application.ViewModels;
namespace teste.application.Query.ParadaQuery;
public record GetParadaQuery() : IRequest<IEnumerable<ParadaViewModel>>;

public class GetParadaQueryHandler : IRequestHandler<GetParadaQuery, IEnumerable<ParadaViewModel>>
{
    private readonly IParadaRepository _paradaRepository;
    private readonly IMapper _mapper; 

    public GetParadaQueryHandler(IParadaRepository paradaRepository, IMapper mapper)
    {
        _paradaRepository = paradaRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ParadaViewModel>> Handle(GetParadaQuery request, CancellationToken cancellationToken)
    {
        var paradas = await _paradaRepository.Get();

        // Usar AutoMapper para mapear a lista de entidades para ViewModels
        return _mapper.Map<IEnumerable<ParadaViewModel>>(paradas);
    }
}