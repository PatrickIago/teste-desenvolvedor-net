namespace teste.infrastructure.SQL;
public static class PosicaoVeiculoSQL
{
    public const string Insert = @"
            INSERT INTO PosicaoVeiculo (Latitude, Longitude, VeiculoId) 
            OUTPUT INSERTED.*
            VALUES (@Latitude, @Longitude, @VeiculoId)";
            
    public const string Delete = @"
            DELETE FROM PosicaoVeiculo WHERE Id = @Id;";

    public const string GetById = @"
            SELECT * FROM PosicaoVeiculo WHERE Id = @Id;";

    public const string GetAll = @"
            SELECT * FROM PosicaoVeiculo;";

    public const string Update = @"
            UPDATE PosicaoVeiculo 
            SET Latitude = @Latitude, Longitude = @Longitude, VeiculoId = @VeiculoId 
            OUTPUT INSERTED.*
            WHERE Id = @Id";
            
}
