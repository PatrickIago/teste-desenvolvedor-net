using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using teste.application.Contract;
using teste.infrastructure.Service; 
namespace teste.infrastructure;
public class SqlInitializer
{
    public static void Initialize(IServiceCollection services, IConfiguration configuration)
    {
        // Registrar a conexão com o banco de dados
        services.AddTransient<IDbConnection>(provider =>
            new SqlConnection(configuration.GetConnectionString("DefaultConnection")));

        // Registrar os serviços
        services.AddTransient<ILinhaRepository, LinhaService>();
        services.AddTransient<IParadaRepository, ParadaService>();
        services.AddTransient<IPosicaoVeiculoRepository, PosicaoVeiculoService>();
        services.AddTransient<IVeiculoRepository, VeiculoService>();
    }
}
