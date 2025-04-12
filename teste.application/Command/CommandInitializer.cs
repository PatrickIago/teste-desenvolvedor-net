using MediatR;
using Microsoft.Extensions.DependencyInjection;
using teste.application.Command.LinhaCommand;
using teste.application.Command.ParadaCommand;
using teste.application.Command.PosicaoVeiculoCommand;
using teste.application.Command.VeiculoCommand;
using teste.application.ViewModels;

namespace teste.application.Command;
public class CommandInitializer
{
    public static void Initialize(IServiceCollection services)
    {
        // Linha
        services.AddTransient<IRequestHandler<CreateLinhaCommand, LinhaViewModel>, CreateLinhaCommandHandler>();
        services.AddTransient<IRequestHandler<UpdateLinhaCommand, LinhaViewModel>, UpdateLinhaCommandHandler>();
        services.AddTransient<IRequestHandler<DeleteLinhaCommand, bool>, DeleteLinhaCommandHandler>();

        // Parada
        services.AddTransient<IRequestHandler<CreateParadaCommand, ParadaViewModel>, CreateParadaCommandHandler>();
        services.AddTransient<IRequestHandler<UpdateParadaCommand, ParadaViewModel>, UpdateParadaCommandHandler>();
        services.AddTransient<IRequestHandler<DeleteParadaCommand, bool>, DeleteParadaCommandHandler>();

        // Veiculo
        services.AddTransient<IRequestHandler<CreateVeiculoCommand, VeiculoViewModel>, CreateVeiculoCommandHandler>();
        services.AddTransient<IRequestHandler<UpdateVeiculoCommand, VeiculoViewModel>, UpdateVeiculoCommandHandler>();
        services.AddTransient<IRequestHandler<DeleteVeiculoCommand, bool>, DeleteVeiculoCommandHandler>();

        // PosicaoVeiculo
        services.AddTransient<IRequestHandler<CreatePosicaoVeiculoCommand, PosicaoVeiculoViewModel>, CreatePosicaoVeiculoCommandHandler>();
        services.AddTransient<IRequestHandler<UpdatePosicaoVeiculoCommand, PosicaoVeiculoViewModel>, UpdatePosicaoVeiculoCommandHandler>();
        services.AddTransient<IRequestHandler<DeletePosicaoVeiculoCommand, bool>, DeletePosicaoVeiculoCommandHandler>();

    }
}
