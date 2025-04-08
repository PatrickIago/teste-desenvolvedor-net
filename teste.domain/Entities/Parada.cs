namespace teste.domain.Entities;
public class ParadaEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public ParadaEntity()
    {
    }

    public ParadaEntity(long id, string name, double latitude, double longitude)
    {
        Id = id;
        Name = name;
        Latitude = latitude;
        Longitude = longitude;
    }
}
