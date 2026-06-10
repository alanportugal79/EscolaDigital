using Entebra.EsolaDigital.Shared.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Entebra.EscolaDigital.Shared.Infrastructure.Persistence;

public sealed class ModuleDbContext : IDisposable
{
    public IDbConnection Connection { get; set; }
    public IDbTransaction? Transaction { get; set; }

    public ModuleDbContext(string connectionString, ITenantService tenantService)
    {
        Connection = new SqlConnection(connectionString.Replace("{tenantID}", tenantService.GetTenantId()));
        Connection.Open();
    }

    public void Dispose() => Connection.Dispose();
}
