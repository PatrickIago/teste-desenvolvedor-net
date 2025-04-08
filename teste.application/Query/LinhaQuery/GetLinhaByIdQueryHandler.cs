using AutoMapper;
using MediatR;
using teste.application.Contract;
using teste.application.ViewModels;

namespace teste.application.Query.LinhaQuery;

public record GetLinhaByIdQuery(long Id) : IRequest<LinhaViewModel>;

public class GetLinhaByIdQueryHandler : IRequestHandler<GetLinhaByIdQuery, LinhaViewModel>
{
    private readonly ILinhaRepository _linhaRepository;
    private readonly IMapper _mapper;

    public GetLinhaByIdQueryHandler(ILinhaRepository linhaRepository, IMapper mapper)
    {
        _linhaRepository = linhaRepository;
        _mapper = mapper;
    }

    public async Task<LinhaViewModel> Handle(GetLinhaByIdQuery request, CancellationToken cancellationToken)
    {
        var linha = await _linhaRepository.Get(request.Id);
        return linha == null ? null : _mapper.Map<LinhaViewModel>(linha);
    }
}
