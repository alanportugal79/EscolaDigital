using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habitat.EscolaDigital.Session.Application.Repository;
using Habitat.EscolaDigital.Session.Persistence.Context;

namespace Habitat.EscolaDigital.Session.Persistence.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly EscolaDigitalContext _context;

    public UnitOfWork(EscolaDigitalContext context)
    {
        _context = context;
    }

    public Task Save(CancellationToken cancellationToken)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
