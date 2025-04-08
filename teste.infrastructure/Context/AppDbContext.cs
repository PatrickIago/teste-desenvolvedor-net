using Microsoft.EntityFrameworkCore;
using teste.domain.Entities;

namespace teste.infrastructure.Context;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<LinhaEntity> Linhas { get; set; }
    public DbSet<ParadaEntity> Parada { get; set; }
    public DbSet<PosicaoVeiculoEntity> PosicaoVeiculo { get; set; }
    public DbSet<VeiculoEntity> Veiculos { get; set; }
}
