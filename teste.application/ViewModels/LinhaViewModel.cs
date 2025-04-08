using teste.domain.Entities;
namespace teste.application.ViewModels;
public class LinhaViewModel
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public ICollection<ParadaEntity> Paradas { get; set; }

    public LinhaViewModel()
    {
    }

    public LinhaViewModel(long id, string nome, ICollection<ParadaEntity> paradas)
    {
        Id = id;
        Nome = nome;
        Paradas = paradas;
    }
}
