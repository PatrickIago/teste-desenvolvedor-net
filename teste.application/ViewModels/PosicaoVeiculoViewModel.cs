namespace teste.application.ViewModels
{
    public class PosicaoVeiculoViewModel
    {
        public long Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public long VeiculoId { get; set; }

        public PosicaoVeiculoViewModel() { }

        public PosicaoVeiculoViewModel(long id, double latitude, double longitude, long veiculoId)
        {
            Id = id;
            Latitude = latitude;
            Longitude = longitude;
            VeiculoId = veiculoId;
        }
    }
}

