using AutoMapper;
using teste.application.ViewModels;
using teste.domain.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Parada
        CreateMap<ParadaEntity, ParadaViewModel>()
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name));

        CreateMap<ParadaViewModel, ParadaEntity>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Nome));

        // Linha
        CreateMap<LinhaEntity, LinhaViewModel>()
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name));

        // PosicaoVeiculo
        CreateMap<PosicaoVeiculoEntity, PosicaoVeiculoViewModel>().ReverseMap();
    }
}
