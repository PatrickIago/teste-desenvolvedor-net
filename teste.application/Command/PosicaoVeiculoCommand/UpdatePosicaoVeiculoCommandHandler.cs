using AutoMapper;
using MediatR;
using teste.application.Contract;
using teste.application.ViewModels;
using teste.domain.Entities;

namespace teste.application.Command.PosicaoVeiculoCommand
{
    public record UpdatePosicaoVeiculoCommand(int Id, double Latitude, double Longitude, int VeiculoId)
        : IRequest<PosicaoVeiculoViewModel>;

    public class UpdatePosicaoVeiculoCommandHandler : IRequestHandler<UpdatePosicaoVeiculoCommand, PosicaoVeiculoViewModel>
    {
        private readonly IPosicaoVeiculoRepository _repo;
        private readonly IMapper _mapper;

        public UpdatePosicaoVeiculoCommandHandler(IPosicaoVeiculoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<PosicaoVeiculoViewModel> Handle(UpdatePosicaoVeiculoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repo.Get(request.Id);
            if (entity is null)
                throw new KeyNotFoundException($"Posição de Veículo com ID {request.Id} não encontrada.");

            // Mapeie o ViewModel para a Entity
            var posicaoVeiculoEntity = _mapper.Map<PosicaoVeiculoEntity>(entity);

            posicaoVeiculoEntity.Latitude = request.Latitude;
            posicaoVeiculoEntity.Longitude = request.Longitude;
            posicaoVeiculoEntity.VeiculoId = request.VeiculoId;

           
            var updatedEntity = await _repo.Update(posicaoVeiculoEntity);

            return updatedEntity;
        }
    }
}