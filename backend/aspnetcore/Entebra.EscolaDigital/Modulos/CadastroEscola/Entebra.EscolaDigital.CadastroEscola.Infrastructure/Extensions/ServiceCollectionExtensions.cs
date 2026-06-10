using Entebra.EscolaDigital.CadastroEscola.Domain.Interfaces;
using Entebra.EscolaDigital.CadastroEscola.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Entebra.EscolaDigital.CadastroEscola.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCadastroEscolaInfrastructure(this IServiceCollection services)
    {
        services
            .AddScoped<IEscolaRepository, EscolaRepository>()
            .AddScoped<ISituacaoEscolaRepository, SituacaoEscolaRepository>()
            .AddScoped<IUnidadeRepository, UnidadeRepository>();

        return services;
    }

}
