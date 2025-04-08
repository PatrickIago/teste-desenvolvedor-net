namespace teste.application.ViewModels;
public class ParadaViewModel
{
    public long Id { get; set; }
    public string? Nome { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    public ParadaViewModel() { }
    
    

    public ParadaViewModel(long id, string nome, double latitude, double longitude)
    {
        Id = id;
        Nome = nome;
        Latitude = latitude;
        Longitude = longitude;
    }
}
