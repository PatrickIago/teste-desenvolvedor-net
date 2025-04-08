using Dapper;
using System.Data;
using teste.application.Contract;
using teste.application.ViewModels;
using teste.infrastructure.SQL;

namespace teste.infrastructure.Service
{
    public class PosicaoVeiculoService : IPosicaoVeiculoRepository
    {
        private readonly IDbConnection _dbConnection;

        public PosicaoVeiculoService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<PosicaoVeiculoViewModel> Create(PosicaoVeiculoViewModel posicaVeiculoModel)
        {
            return await _dbConnection.QuerySingleAsync<PosicaoVeiculoViewModel>(
                PosicaoVeiculoSQL.Insert,
                new { posicaVeiculoModel.Latitude, posicaVeiculoModel.Longitude, posicaVeiculoModel.VeiculoId }
            );
        }

        public async Task<bool> Delete(int id)
        {
            var rowsAffected = await _dbConnection.ExecuteAsync(
                PosicaoVeiculoSQL.Delete,
                new { Id = id }
            );
            return rowsAffected > 0;
        }

        public async Task<List<PosicaoVeiculoViewModel>> Get()
        {
            var posicoes = await _dbConnection.QueryAsync<PosicaoVeiculoViewModel>(PosicaoVeiculoSQL.GetAll);
            return posicoes.AsList();
        }

        public async Task<PosicaoVeiculoViewModel?> Get(int id)
        {
            return await _dbConnection.QueryFirstOrDefaultAsync<PosicaoVeiculoViewModel>(
                PosicaoVeiculoSQL.GetById,
                new { Id = id }
            );
        }

        public async Task<PosicaoVeiculoViewModel?> Update(PosicaoVeiculoViewModel posicaVeiculoModel)
        {
            return await _dbConnection.QuerySingleOrDefaultAsync<PosicaoVeiculoViewModel>(
                PosicaoVeiculoSQL.Update,
                new { posicaVeiculoModel.Latitude, posicaVeiculoModel.Longitude, posicaVeiculoModel.VeiculoId, posicaVeiculoModel.Id }
            );
        }
    }
}
