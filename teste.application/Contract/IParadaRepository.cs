using teste.application.ViewModels;
using teste.domain.Entities;
namespace teste.application.Contract;
public interface IParadaRepository
{
    Task<List<ParadaViewModel>> Get();
    Task<ParadaEntity?> Get(long id);
    Task<ParadaEntity> Create(ParadaEntity parada);
    Task<ParadaEntity?> Update(ParadaEntity parada);
    Task<bool> Delete(long id);
}
