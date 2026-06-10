using Entebra.EscolaDigital.CadastroEscola;
using Entebra.EscolaDigital.Shared.Infrastructure.Extensions;
using Entebra.EscolaDigital.Shared.Infrastructure.Middleware;
using Entebra.EscolaDigital.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Adiciona Shared
builder.Services.AddSharedInfrastructure(builder.Configuration);

// Adiciona módulos
builder.Services.AddCadastroEscolaModule(builder.Configuration);

builder.Services.AddAuthenticationConfiguration(builder.Configuration);

builder.Services.AddOpenApi();
builder.Services.AddSwaggerConfig(builder.Configuration);

var app = builder.Build();

// global error handler
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{    
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
