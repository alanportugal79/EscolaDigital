using Serilog;

namespace Habitat.EscolaDigital.Session.WebApi.Extensions;

public static class LogExtensions
{
    public static void ConfigureLog(this ConfigureHostBuilder configureHostBuilder)
    {
        var outputTemplate = "{Timestamp:dd/MM/yyyy HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}";

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console(outputTemplate: outputTemplate)
            .WriteTo.File(
                "logs/logs.txt",
                rollingInterval: RollingInterval.Day,
                outputTemplate: outputTemplate
            )
            .Enrich.FromLogContext()
            .CreateLogger();

        configureHostBuilder.UseSerilog();
    }
}
