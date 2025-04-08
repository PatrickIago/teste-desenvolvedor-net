public static class ParadaSQL
{
    public const string Insert = @"
           INSERT INTO Parada (Name, Latitude, Longitude) 
           OUTPUT INSERTED.*
           VALUES (@Name, @Latitude, @Longitude);";

    public const string Delete = @"
            DELETE FROM Parada WHERE Id = @Id;";

    public const string GetById = @"
            SELECT Id, Name, Latitude, Longitude FROM Parada WHERE Id = @Id;";

    public const string GetAll = @"
            SELECT Id, Name AS Nome, Latitude, Longitude FROM Parada;";

    public const string Update = @"
            UPDATE Parada
            SET Name = @Name, Latitude = @Latitude, Longitude = @Longitude 
            OUTPUT INSERTED.*
            WHERE Id = @Id";

    public const string GetByNames = @"
            SELECT * FROM Parada 
            WHERE Name IN @Nomes;";

    public const string GetByIds = @"
            SELECT Id, Name, Latitude, Longitude 
            FROM Parada 
            WHERE Id IN @Ids;";
}