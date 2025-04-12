namespace teste.domain.Entities;
public class PosicaoVeiculoEntity
{
    public int Id { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public long VeiculoId { get; set; }
}
