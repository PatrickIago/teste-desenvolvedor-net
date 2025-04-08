using AutoMapper;
using MediatR;
using teste.application.Contract;
using teste.application.ViewModels;

namespace teste.application.Query.LinhaQuery;

public record GetLinhaQuery() : IRequest<IEnumerable<LinhaViewModel>>;

public class GetLinhaQueryHandler : IRequestHandler<GetLinhaQuery, IEnumerable<LinhaViewModel>>
{
    private readonly ILinhaRepository _linhaRepository;
    private readonly IMapper _mapper;

    public GetLinhaQueryHandler(ILinhaRepository linhaRepository, IMapper mapper)
    {
        _linhaRepository = linhaRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LinhaViewModel>> Handle(GetLinhaQuery request, CancellationToken cancellationToken)
    {
        var linhas = await _linhaRepository.Get();
        return _mapper.Map<IEnumerable<LinhaViewModel>>(linhas);
    }
}
