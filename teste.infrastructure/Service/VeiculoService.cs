using Dapper;
using System.Data;
using teste.application.Contract;
using teste.application.ViewModels;
using teste.domain.Entities;
using teste.infrastructure.SQL;

namespace teste.infrastructure.Service;

public class VeiculoService : IVeiculoRepository
{
    private readonly IDbConnection _dbConnection;

    public VeiculoService(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<VeiculoEntity> Create(VeiculoEntity veiculo)
    {
        return await _dbConnection.QuerySingleAsync<VeiculoEntity>(
            VeiculoSQL.Insert,
            new { veiculo.Nome, veiculo.Modelo, veiculo.LinhaId }
        );
    }

    public async Task<bool> Delete(long id)
    {
        var rowsAffected = await _dbConnection.ExecuteAsync(
            VeiculoSQL.Delete,
            new { Id = id }
        );
        return rowsAffected > 0;
    }

    public async Task<List<VeiculoViewModel>> Get()
    {
        var veiculos = await _dbConnection.QueryAsync<VeiculoViewModel>(VeiculoSQL.GetAll);
        return veiculos.AsList();
    }

    public async Task<VeiculoViewModel?> Get(long id)
    {
        return await _dbConnection.QueryFirstOrDefaultAsync<VeiculoViewModel>(
            VeiculoSQL.GetById,
            new { Id = id }
        );
    }

    public async Task<List<VeiculoViewModel>> GetByLinhaId(long linhaId)
    {
        var veiculos = await _dbConnection.QueryAsync<VeiculoViewModel>(VeiculoSQL.GetByLinhaId, new { LinhaId = linhaId });
        return veiculos.AsList();
    }

    public async Task<VeiculoViewModel?> Update(VeiculoViewModel veiculo)
    {
        return await _dbConnection.QuerySingleOrDefaultAsync<VeiculoViewModel>(
            VeiculoSQL.Update,
            new { veiculo.Id, veiculo.Nome, veiculo.Modelo, veiculo.LinhaId }
        );
    }
}
