namespace teste.infrastructure.SQL;
public static class VeiculoSQL
{
    public const string Insert = @"
            INSERT INTO Veiculos (Nome, Modelo, LinhaId) 
            OUTPUT INSERTED.*
            VALUES (@Nome, @Modelo, @LinhaId)";        

    public const string Delete = @"
            DELETE FROM Veiculos WHERE Id = @Id;";

    public const string GetById = @"
            SELECT * FROM Veiculos WHERE Id = @Id;";

    public const string GetAll = @"
            SELECT * FROM Veiculos;";

    public const string Update = @"
            UPDATE Veiculos 
            SET Nome = @Nome, Modelo = @Modelo, LinhaId = @LinhaId
            OUTPUT INSERTED.*
            WHERE Id = @Id";
            
}
