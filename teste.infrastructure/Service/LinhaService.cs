using Dapper;
using System.Data;
using teste.application.Contract;
using teste.domain.Entities;
using teste.infrastructure.SQL;

namespace teste.infrastructure.Service;
public class LinhaService : ILinhaRepository
{
    private readonly IDbConnection _dbConnection;

    public LinhaService(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<LinhaEntity> Create(LinhaEntity linhaEntity)
    {
        return await _dbConnection.QuerySingleAsync<LinhaEntity>(
            LinhaSQL.Insert,
            new { linhaEntity.Name }
        );
    }

    public async Task<bool> Delete(long id)
    {
        var rowsAffected = await _dbConnection.ExecuteAsync(LinhaSQL.Delete, new { Id = id });
        return rowsAffected > 0;
    }

    public async Task<List<LinhaEntity>> Get()
    {
        var result = await _dbConnection.QueryAsync<LinhaEntity>(
            LinhaSQL.GetAll 
        );

        return result.ToList();
    }

    public async Task<LinhaEntity?> Get(long id)
    {
        return await _dbConnection.QueryFirstOrDefaultAsync<LinhaEntity>(
            LinhaSQL.GetById,
            new { Id = id }
        );
    }

    public async Task<List<ParadaEntity>> GetParadasByNamesAsync(IEnumerable<string> nomes)
    {
        var query = ParadaSQL.GetByNames;
        var paradas = await _dbConnection.QueryAsync<ParadaEntity>(query, new { Nomes = nomes });
        return paradas.AsList();
    }

    public async Task<LinhaEntity?> Update(LinhaEntity linhaEntity)
    {
        return await _dbConnection.QuerySingleOrDefaultAsync<LinhaEntity>(
            LinhaSQL.Update,
            new { linhaEntity.Id, linhaEntity.Name }
        );
    }

    public async Task<List<ParadaEntity>> GetParadasByIdsAsync(IEnumerable<long> ids)
    {
        var query = ParadaSQL.GetByIds;
        var paradas = await _dbConnection.QueryAsync<ParadaEntity>(query, new { Ids = ids });
        return paradas.AsList();
    }
}
