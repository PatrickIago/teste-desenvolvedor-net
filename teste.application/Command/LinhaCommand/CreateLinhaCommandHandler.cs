using AutoMapper;
using MediatR;
using teste.application.Contract;
using teste.application.ViewModels;
using teste.domain.Entities;
public record CreateLinhaCommand(string Name, ICollection<ParadaViewModel> Paradas) : IRequest<LinhaViewModel>;

public class CreateLinhaCommandHandler : IRequestHandler<CreateLinhaCommand, LinhaViewModel>
{
    private readonly ILinhaRepository _repo;
    private readonly IMapper _mapper;

    public CreateLinhaCommandHandler(ILinhaRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<LinhaViewModel> Handle(CreateLinhaCommand request, CancellationToken cancellationToken)
    {
        // Filtra apenas paradas com Id válido (> 0)
        var paradaIds = request.Paradas
            .Where(p => p.Id > 0)
            .Select(p => p.Id)
            .ToList();

        // Busca as paradas já cadastradas no banco por ID
        var paradasExistentes = await _repo.GetParadasByIdsAsync(paradaIds);

        // Cria a Linha com as paradas existentes
        var linhaEntity = new LinhaEntity
        {
            Name = request.Name,
            Paradas = paradasExistentes
        };

        var createdLinha = await _repo.Create(linhaEntity);

        return _mapper.Map<LinhaViewModel>(createdLinha);
    }

}
