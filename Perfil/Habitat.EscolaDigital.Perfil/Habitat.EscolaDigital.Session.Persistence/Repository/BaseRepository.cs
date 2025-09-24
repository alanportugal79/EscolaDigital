using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habitat.EscolaDigital.Session.Application.Repository;
using Habitat.EscolaDigital.Session.Domain.Common;
using Habitat.EscolaDigital.Session.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Habitat.EscolaDigital.Session.Persistence.Repository;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseAuditableEntity
{
    protected readonly EscolaDigitalContext Context;

    public BaseRepository(EscolaDigitalContext context)
    {
        Context = context;
    }

    public void Create(T entity)
    {
        entity.DateCreated = DateTime.Now;
        Context.Add(entity);
    }

    public void Update(T entity)
    {
        Context.Update(entity);
    }

    public void Delete(T entity)
    {
        entity.DateDeleted = DateTime.Now;
        entity.IsDeleted = true;
        Context.Update(entity);
    }

    public Task<T> Get(long id, CancellationToken cancellationToken)
    {
        return Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public Task<T> Get(Guid idGuid, CancellationToken cancellationToken)
    {
        return Context.Set<T>().FirstOrDefaultAsync(x => x.IdGuid == idGuid, cancellationToken);
    }

    public Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return Context.Set<T>().ToListAsync(cancellationToken);
    }
}
