using Dapper;
using System.Data;
using teste.application.Contract;
using teste.application.ViewModels;
using teste.domain.Entities;
using teste.infrastructure.SQL;

namespace teste.infrastructure.Service;

public class ParadaService : IParadaRepository
{
    private readonly IDbConnection _dbConnection;

    public ParadaService(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<ParadaEntity> Create(ParadaEntity parada)
    {
        return await _dbConnection.QuerySingleAsync<ParadaEntity>(
            ParadaSQL.Insert,
            new { Name = parada.Name, Latitude = parada.Latitude, Longitude = parada.Longitude } 
        );
    }

    public async Task<bool> Delete(long id)
    {
        var rowsAffected = await _dbConnection.ExecuteAsync(
            ParadaSQL.Delete,
            new { Id = id }
        );
        return rowsAffected > 0;
    }

    public async Task<List<ParadaViewModel>> Get()
    {
        var paradas = await _dbConnection.QueryAsync<ParadaViewModel>(ParadaSQL.GetAll);
        return paradas.AsList();
    }

    public async Task<ParadaEntity?> Get(long id)
    {
        return await _dbConnection.QueryFirstOrDefaultAsync<ParadaEntity>(
            ParadaSQL.GetById,
            new { Id = id }
        );
    }

    public async Task<ParadaEntity?> Update(ParadaEntity parada)
    {
        return await _dbConnection.QuerySingleOrDefaultAsync<ParadaEntity>(
            ParadaSQL.Update,
            new { parada.Id, parada.Name, parada.Latitude, parada.Longitude }
        );
    }
}
