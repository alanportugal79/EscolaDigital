using Entebra.EscolaDigital.CadastroEscola.Core.Interfaces;
using Entebra.EscolaDigital.CadastroEscola.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Entebra.EscolaDigital.CadastroEscola.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCadastroEscolaCore(this IServiceCollection services)
    {
        services.AddScoped<IEscolaService, EscolaService>()
            .AddScoped<ISituacaoEscolaService, SituacaoEscolaService>();
        return services;
    }
}
