using Entebra.EscolaDigital.CadastroEscola.Core.Extensions;
using Entebra.EscolaDigital.CadastroEscola.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Entebra.EscolaDigital.CadastroEscola;

public static class ModuleExtensions
{
    public static IServiceCollection AddCadastroEscolaModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCadastroEscolaCore()
            .AddCadastroEscolaInfrastructure();
        return services;
    }
}
