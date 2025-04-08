using teste.domain.Entities;
namespace teste.application.Contract;
public interface ILinhaRepository
{
    Task<List<ParadaEntity>> GetParadasByNamesAsync(IEnumerable<string> nomes);
    Task<List<LinhaEntity>> Get();
    Task<LinhaEntity?> Get(long id);
    Task<LinhaEntity> Create(LinhaEntity linhaEntity);
    Task<LinhaEntity?> Update(LinhaEntity linhaEntity);
    Task<bool> Delete(long id);
    Task<List<ParadaEntity>> GetParadasByIdsAsync(IEnumerable<long> ids);

}
