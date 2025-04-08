namespace teste.application.ViewModels
{
    public class PosicaoVeiculoViewModel
    {
        public long Id { get; set; }
        public double Latitude { get; set; } 
        public double Longitude { get; set; } 
        public int VeiculoId { get; set; } 
        public VeiculoViewModel Veiculo { get; set; }

        public PosicaoVeiculoViewModel(long id, double latitude, double longitude, int veiculoId, VeiculoViewModel veiculo)
        {
            Id = id;
            Latitude = latitude; 
            VeiculoId = veiculoId; 
            Veiculo = veiculo;
        }
        }
    }

