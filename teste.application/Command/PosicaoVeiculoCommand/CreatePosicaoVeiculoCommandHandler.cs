using AutoMapper;
using MediatR;
using teste.application.Contract;
using teste.application.ViewModels;
using teste.domain.Entities;

namespace teste.application.Command.PosicaoVeiculoCommand;

public record CreatePosicaoVeiculoCommand(double Latitude, double Longitude, int VeiculoId)
    : IRequest<PosicaoVeiculoViewModel>;

public class CreatePosicaoVeiculoCommandHandler : IRequestHandler<CreatePosicaoVeiculoCommand, PosicaoVeiculoViewModel>
{
    private readonly IPosicaoVeiculoRepository _repo;
    private readonly IMapper _mapper;

    public CreatePosicaoVeiculoCommandHandler(IPosicaoVeiculoRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<PosicaoVeiculoViewModel> Handle(CreatePosicaoVeiculoCommand request, CancellationToken cancellationToken)
    {
        var entity = new PosicaoVeiculoEntity
        {
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            VeiculoId = request.VeiculoId
        };

        var result = await _repo.Create(entity);
        return _mapper.Map<PosicaoVeiculoViewModel>(result);
    }
}
