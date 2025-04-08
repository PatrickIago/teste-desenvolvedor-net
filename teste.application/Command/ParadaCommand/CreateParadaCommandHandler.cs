using AutoMapper;
using MediatR;
using teste.application.Contract;
using teste.application.ViewModels;
using teste.domain.Entities;
namespace teste.application.Command.ParadaCommand;

public record CreateParadaCommand(string Nome, double Latitude, double Longitude) : IRequest<ParadaViewModel>;

public class CreateParadaCommandHandler : IRequestHandler<CreateParadaCommand, ParadaViewModel>
{
    private readonly IParadaRepository _repo;
    private readonly ILinhaRepository _linhaRepo;
    private readonly IMapper _mapper; 

    public CreateParadaCommandHandler(IParadaRepository repo, ILinhaRepository linhaRepo, IMapper mapper)
    {
        _repo = repo;
        _linhaRepo = linhaRepo;
        _mapper = mapper; 
    }

    public async Task<ParadaViewModel> Handle(CreateParadaCommand request, CancellationToken cancellationToken)
    {
        var paradaEntity = new ParadaEntity
        {
            Name = request.Nome,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
        };

        // Salvar no repositório
        var createdParada = await _repo.Create(paradaEntity);

        // Usar AutoMapper para mapear a entidade criada para ViewModel
        return _mapper.Map<ParadaViewModel>(createdParada);
    }
}

