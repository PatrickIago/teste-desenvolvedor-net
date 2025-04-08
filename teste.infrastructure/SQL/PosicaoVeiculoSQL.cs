namespace teste.infrastructure.SQL;
public static class PosicaoVeiculoSQL
{
    public const string Insert = @"
            INSERT INTO PosicoesVeiculos (Latitude, Longitude, VeiculoId) 
            VALUES (@Latitude, @Longitude, @VeiculoId)
            RETURNING *;";

    public const string Delete = @"
            DELETE FROM PosicoesVeiculos WHERE Id = @Id;";

    public const string GetById = @"
            SELECT * FROM PosicoesVeiculos WHERE Id = @Id;";

    public const string GetAll = @"
            SELECT * FROM PosicoesVeiculos;";

    public const string Update = @"
            UPDATE PosicoesVeiculos 
            SET Latitude = @Latitude, Longitude = @Longitude, VeiculoId = @VeiculoId 
            WHERE Id = @Id
            RETURNING *;";
}
