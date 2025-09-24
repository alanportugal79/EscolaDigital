using Microsoft.OpenApi.Models;

namespace Habitat.EscolaDigital.Session.WebApi.Extensions;

public static class SwaggerExtentions
{
    public static void ConfigSwagger(this IServiceCollection services, IConfiguration configuration)
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
                        AuthorizationUrl = new Uri(configuration.GetSection("auth")["authorization-url"] ?? "http://localhost:8080/realms/EscolaDigital/protocol/openid-connect/auth"),
                        Scopes = new Dictionary<string, string>
                        {                            
                            { "session_api.all", "session_api.all" }
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
