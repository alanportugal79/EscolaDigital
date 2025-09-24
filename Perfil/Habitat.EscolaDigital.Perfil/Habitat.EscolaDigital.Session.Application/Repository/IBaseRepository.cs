using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habitat.EscolaDigital.Session.Domain.Common;

namespace Habitat.EscolaDigital.Session.Application.Repository;

public interface IBaseRepository<T> where T : BaseEntity
{
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T> Get(long id, CancellationToken cancellationToken);
    Task<T> Get(Guid idGuid, CancellationToken cancellationToken);
    Task<List<T>> GetAll(CancellationToken cancellationToken);
}
