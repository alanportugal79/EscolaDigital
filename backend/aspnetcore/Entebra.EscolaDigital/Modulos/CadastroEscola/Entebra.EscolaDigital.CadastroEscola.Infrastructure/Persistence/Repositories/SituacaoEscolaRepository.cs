using Dapper;
using Entebra.EscolaDigital.CadastroEscola.Domain.Entities;
using Entebra.EscolaDigital.CadastroEscola.Domain.Interfaces;
using Entebra.EscolaDigital.CadastroEscola.Infrastructure.Persistence.Queries;
using Entebra.EscolaDigital.Shared.Infrastructure.Persistence;

namespace Entebra.EscolaDigital.CadastroEscola.Infrastructure.Persistence.Repositories;

public class SituacaoEscolaRepository : ISituacaoEscolaRepository
{
    private readonly ModuleDbContext _dbContext;
    public SituacaoEscolaRepository(ModuleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<SituacaoEscola>> GetAllAsync()
    {        
        var result = await _dbContext.Connection.QueryAsync<SituacaoEscola>(SituacaoEscolaQuery.GetAll, transaction: _dbContext.Transaction);
        return result;
    }
}
