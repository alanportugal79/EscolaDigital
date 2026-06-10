namespace Entebra.EscolaDigital.Shared.Infrastructure.Persistence;

public class UnitOfWork
{
    private readonly ModuleDbContext _context;
    private bool _disposed;
    public UnitOfWork(ModuleDbContext context)
    {
        _context = context;        
    }

    public void BeginTransaction()
    {
        _context.Transaction = _context.Connection.BeginTransaction();
    }
    public void Commit()
    {
        try
        {
            _context.Transaction?.Commit();
        }
        catch
        {
            Rollback();
            throw;
        }
        finally
        {
            Dispose();
        }
    }
    public void Rollback()
    {
        _context.Transaction?.Rollback();
        Dispose();
    }
    public void Dispose()
    {
        if (!_disposed)
        {
            _context.Transaction?.Dispose();
            _context.Dispose();
            _disposed = true;
        }
    }
}
