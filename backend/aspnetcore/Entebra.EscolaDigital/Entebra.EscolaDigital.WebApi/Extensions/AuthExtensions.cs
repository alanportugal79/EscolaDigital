using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Entebra.EscolaDigital.WebApi.Extensions;

public static class AuthExtensions
{
    public static void AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.Authority = configuration.GetSection("auth")["auth-server-url"];
                options.Audience = configuration.GetSection("auth")["resource"];
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration.GetSection("auth")["auth-server-url"],
                    ValidateAudience = true,
                    ValidAudience = configuration.GetSection("auth")["resource"],
                    ValidateLifetime = true
                };

                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        // Custom token validation logic here, if needed
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        // Handle authentication failures
                        return Task.CompletedTask;
                    }
                };
            });
    }
}
