namespace teste.application.ViewModels;
public class VeiculoViewModel
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public string Modelo { get; set; }
    public long LinhaId { get; set; }

    public VeiculoViewModel() { }


    public VeiculoViewModel(long id, string nome, string modelo, long linhaId)
    {
        Id = id;
        Nome = nome;
        Modelo = modelo;
        LinhaId = linhaId;
    }
}