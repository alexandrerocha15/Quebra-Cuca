using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuebraCuca.Aplicacao.Modulos.ModuloDiamante;

namespace QuebraCuca.Aplicacao;

public static class InjecaoDependencia
{
    public static void AddApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddScoped<ServicoDiamante>();
    }
}
