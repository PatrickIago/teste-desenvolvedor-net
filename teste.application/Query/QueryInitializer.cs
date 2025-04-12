using MediatR;
using Microsoft.Extensions.DependencyInjection;
using teste.application.Query.LinhaQuery;
using teste.application.Query.ParadaQuery;
using teste.application.Query.PosicaoVeiculoQuery;
using teste.application.Query.VeiculoQuery;
using teste.application.ViewModels;
namespace teste.application.Query;

public class QueryInitializer
{
    public static void Initialize(IServiceCollection services)
    {
        // Linha
        services.AddTransient<IRequestHandler<GetLinhaQuery, IEnumerable<LinhaViewModel>>, GetLinhaQueryHandler>();
        services.AddTransient<IRequestHandler<GetLinhaByIdQuery, LinhaViewModel>, GetLinhaByIdQueryHandler>();

        // Parada
        services.AddTransient<IRequestHandler<GetParadaQuery, IEnumerable<ParadaViewModel>>, GetParadaQueryHandler>();
        services.AddTransient<IRequestHandler<GetParadaByIdQuery, ParadaViewModel>, GetParadaByIdQueryHandler>();

        // Veiculo
        services.AddTransient<IRequestHandler<GetVeiculoQuery, IEnumerable<VeiculoViewModel>>, GetVeiculoQueryHandler>();
        services.AddTransient<IRequestHandler<GetVeiculoByIdQuery, VeiculoViewModel>, GetVeiculoByIdQueryHandler>();

        // Veículos por Linha
        services.AddTransient<IRequestHandler<GetVeiculosByLinhaIdQuery, IEnumerable<VeiculoViewModel>>, GetVeiculosByLinhaIdQueryHandler>();

        // PosicaoVeiculo
        services.AddTransient<IRequestHandler<GetPosicaoVeiculoQuery, IEnumerable<PosicaoVeiculoViewModel>>, GetPosicaoVeiculoQueryHandler>();
        services.AddTransient<IRequestHandler<GetPosicaoVeiculoByIdQuery, PosicaoVeiculoViewModel>, GetPosicaoVeiculoByIdQueryHandler>();
    }
}