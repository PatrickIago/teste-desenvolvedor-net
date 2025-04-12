using teste.application.ViewModels;
using teste.domain.Entities;
namespace teste.application.Contract;

public interface IPosicaoVeiculoRepository
{
    Task<List<PosicaoVeiculoViewModel>> Get();
    Task<PosicaoVeiculoViewModel?> Get(int id);
    Task<PosicaoVeiculoViewModel> Create(PosicaoVeiculoEntity posicaoVeiculo);
    Task<PosicaoVeiculoViewModel?> Update(PosicaoVeiculoEntity posicaoVeiculo);
    Task<bool> Delete(int id);
}