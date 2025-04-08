using AutoMapper;
using MediatR;
using teste.application.Contract;
using teste.application.ViewModels;

namespace teste.application.Query.ParadaQuery;
public record GetParadaByIdQuery(long id) : IRequest<ParadaViewModel>;
public class GetParadaByIdQueryHandler : IRequestHandler<GetParadaByIdQuery, ParadaViewModel>
{
    private readonly IParadaRepository _paradaRepository;
    private readonly IMapper _mapper; 

    public GetParadaByIdQueryHandler(IParadaRepository paradaRepository, IMapper mapper)
    {
        _paradaRepository = paradaRepository;
        _mapper = mapper; 
    }

    public async Task<ParadaViewModel> Handle(GetParadaByIdQuery request, CancellationToken cancellationToken)
    {
        var parada = await _paradaRepository.Get(request.id);

        if (parada == null)
        {
            return null;
        }

        // Usar AutoMapper para mapear a entidade para ViewModel
        return _mapper.Map<ParadaViewModel>(parada);
    }
}

