using Habitat.EscolaDigital.Session.Persistence;
using Habitat.EscolaDigital.Session.Application;
using Habitat.EscolaDigital.Session.WebApi.Extensions;
using Serilog;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.IdentityModel.Logging;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

IdentityModelEventSource.ShowPII = true;


builder.Host.ConfigureLog();

// Add services to the container.

builder.Services.AddHttpContextAccessor();

builder.Services.ConfigurePersistence(builder.Configuration);
builder.Services.ConfigureApplication();

builder.Services.ConfigureApiBehavior();
//builder.Services.ConfigureCorsPolicy();

builder.Services.AddAuthenticationConfiguration(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.ConfigSwagger(builder.Configuration);

var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "SessionFiles")),
    RequestPath = "/Sessionfiles"
});

app.UseErrorHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        
        options.OAuthClientId("web");        
        options.OAuthUsePkce();
        options.OAuthScopeSeparator(" ");
    });

}

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
