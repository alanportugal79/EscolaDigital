using Microsoft.OpenApi.Models;

namespace Entebra.EscolaDigital.WebApi.Extensions;

public static class SwaggerExtensions
{
    public static void AddSwaggerConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Escola Digital", Version = "v1" });            
            options.AddSecurityDefinition("Keycloak", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    Implicit = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri(configuration.GetSection("auth")["authorization-url"] ?? ""),
                        TokenUrl = new Uri("https://auth.entebra.com.br/realms/EscolaDigital/protocol/openid-connect/token"),
                        Scopes = new Dictionary<string, string>
                        {
                            { "web-api-audience", "web-api" },
                            { "microprofile-jwt", "microprofile-jwt"},
                            { "group-attributes", "group-attributes"}
                        },
                        

                    },
                }
            });

            OpenApiSecurityScheme keycloakSecurityScheme = new()
            {
                Reference = new OpenApiReference
                {
                    Id = "Keycloak",
                    Type = ReferenceType.SecurityScheme,
                },
                In = ParameterLocation.Header,
                Name = "Bearer",
                Scheme = "Bearer",
            };

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { keycloakSecurityScheme, Array.Empty<string>() },
            });
        });
    }
}
