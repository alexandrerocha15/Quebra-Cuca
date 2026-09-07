using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuebraCuca.Aplicacao.Modulos.ModuloCheque;
using QuebraCuca.Aplicacao.Modulos.ModuloDiamante;
using QuebraCuca.Aplicacao.Modulos.ModuloNumerosRomanos;

namespace QuebraCuca.Aplicacao;

public static class InjecaoDependencia
{
    public static void AddApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddScoped<ServicoDiamante>();
        services.AddScoped<ServicoCheque>();
        services.AddScoped<ServicoNumerosRomanos>();
    }
}
