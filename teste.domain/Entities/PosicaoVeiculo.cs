namespace teste.domain.Entities;
public class PosicaoVeiculoEntity
{
    public int Id { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int VeiculoId { get; set; }
    public VeiculoEntity Veiculo { get; set; }
}
