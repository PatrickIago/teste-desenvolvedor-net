using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using teste.infrastructure;
using teste.infrastructure.Context;
using teste.application.Query;
using teste.application.Command;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Configurar Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Teste para Dev .net",
        Version = "1.0",
        Description = ".",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Patrick",
            Email = "Mendespatrick720@gmail.com"
        }
    });
});

// Configurar DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

// Inicializar serviços SQL
SqlInitializer.Initialize(builder.Services, configuration);

// Configurar MediatR
builder.Services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(SqlInitializer).Assembly);

// Inicializar serviços de queries
QueryInitializer.Initialize(builder.Services);

// Inicializar serviços de command
CommandInitializer.Initialize(builder.Services);

// Configurar AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly); 

// Configurar os serviços para a API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configurar pipeline de requisição HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();