using AutoMapper;
using MediatR;
using teste.application.Contract;
using teste.application.ViewModels;
using teste.domain.Entities;

namespace teste.application.Command.LinhaCommand;

public record UpdateLinhaCommand(long Id, string Name, ICollection<ParadaViewModel> Paradas) : IRequest<LinhaViewModel>;

public class UpdateLinhaCommandHandler : IRequestHandler<UpdateLinhaCommand, LinhaViewModel>
{
    private readonly ILinhaRepository _repo;
    private readonly IMapper _mapper;

    public UpdateLinhaCommandHandler(ILinhaRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<LinhaViewModel> Handle(UpdateLinhaCommand request, CancellationToken cancellationToken)
    {
        var linha = await _repo.Get(request.Id);

        // Validar se a Linha existe
        if (linha == null)
        {
            throw new KeyNotFoundException($"Linha com ID {request.Id} não encontrada.");
        }

        // Buscar as paradas já cadastradas no banco
        var idsParadas = request.Paradas.Select(p => p.Id);
        var paradasExistentes = await _repo.GetParadasByIdsAsync(idsParadas);

        // Identificar quais paradas são novas
        var novasParadas = request.Paradas
            .Where(p => !paradasExistentes.Any(pe => pe.Name == p.Nome))
            .Select(p => new ParadaEntity { Name = p.Nome })
            .ToList();

        // Atualizar os campos da Linha existente
        linha.Name = request.Name;
        linha.Paradas = paradasExistentes.Concat(novasParadas).ToList();

        // Persistir alterações no repositório
        var updatedLinha = await _repo.Update(linha);

        // Retornar a entidade atualizada como ViewModel usando AutoMapper
        return _mapper.Map<LinhaViewModel>(updatedLinha);
    }
}
