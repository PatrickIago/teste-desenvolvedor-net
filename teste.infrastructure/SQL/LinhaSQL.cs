namespace teste.infrastructure.SQL;
public static class LinhaSQL
{
    public const string Insert = @"
        INSERT INTO Linhas (Name) 
        OUTPUT INSERTED.* 
        VALUES (@Name);";

    public const string Delete = @"
        DELETE FROM Linhas WHERE Id = @Id;";

    public const string GetById = @"
        SELECT * FROM Linhas WHERE Id = @Id;";

    public const string GetAll = @"
        SELECT * FROM Linhas";

    public const string Update = @"
        UPDATE Linhas 
        SET Name = @Name 
        OUTPUT INSERTED.* 
        WHERE Id = @Id;";
}
