using AutoMapper;
using MediatR;
using teste.application.Contract;
using teste.application.ViewModels;

namespace teste.application.Command.ParadaCommand;

public record UpdateParadaCommand(
    long Id,
    string Nome,
    double Latitude,
    double Longitude)
    : IRequest<ParadaViewModel>;

public class UpdateParadaCommandHandler : IRequestHandler<UpdateParadaCommand, ParadaViewModel>
{
    private readonly IParadaRepository _repo;
    private readonly IMapper _mapper; 

    public UpdateParadaCommandHandler(IParadaRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper; 
    }

    public async Task<ParadaViewModel> Handle(UpdateParadaCommand request, CancellationToken cancellationToken)
    {
        // Buscar a parada existente
        var paradaEntity = await _repo.Get(request.Id)
            ?? throw new KeyNotFoundException($"Parada com ID {request.Id} não encontrada.");

        // Atualizar os dados da parada
        paradaEntity.Name = request.Nome;
        paradaEntity.Latitude = request.Latitude;
        paradaEntity.Longitude = request.Longitude;

        // Salvar mudanças no repositório
        var updatedParada = await _repo.Update(paradaEntity);

        // Usar AutoMapper para mapear a entidade atualizada para ViewModel
        return _mapper.Map<ParadaViewModel>(updatedParada);
    }
}
