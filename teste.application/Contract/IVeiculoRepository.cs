using teste.application.ViewModels;
using teste.domain.Entities;
namespace teste.application.Contract;
public interface IVeiculoRepository
{
    Task<List<VeiculoViewModel>> Get();
    Task<VeiculoViewModel> Get(long id);
    Task<VeiculoEntity> Create(VeiculoEntity veiculo);
    Task<VeiculoViewModel> Update(VeiculoViewModel veiculo);
    Task<bool> Delete(long id);

    // Metodo para obter  veículos por linha
    Task<List<VeiculoViewModel>> GetByLinhaId(long linhaId);

}
