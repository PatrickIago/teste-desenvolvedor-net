namespace teste.domain.Entities;
public class LinhaEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public ICollection<ParadaEntity> Paradas { get; set; } = new List<ParadaEntity>();

}
