using Dapper;
using Entebra.EscolaDigital.CadastroEscola.Domain.Entities;
using Entebra.EscolaDigital.CadastroEscola.Domain.Interfaces;
using Entebra.EscolaDigital.CadastroEscola.Infrastructure.Persistence.Queries;
using Entebra.EscolaDigital.Shared.Infrastructure.Persistence;


namespace Entebra.EscolaDigital.CadastroEscola.Infrastructure.Persistence.Repositories;

public class EscolaRepository : IEscolaRepository
{
    private readonly ModuleDbContext _dbContext;

    public EscolaRepository(ModuleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Escola>> GetAllAsync()
    {
        var result = await _dbContext.Connection.QueryAsync<Escola>(EscolaQuery.GetAll, transaction: _dbContext.Transaction);
        return result;
    }

    public async Task<Escola?> GetByIdAsync(int id)
    {
        var result = await _dbContext.Connection.QuerySingleOrDefaultAsync<Escola>(EscolaQuery.GetById, new { ID = id }, transaction: _dbContext.Transaction);
        return result;
    }

    public async Task<Escola?> GetByUidAsync(Guid uid)
    {
        var result = await _dbContext.Connection.QuerySingleOrDefaultAsync<Escola>(EscolaQuery.GetByUid, new { UID = uid }, transaction: _dbContext.Transaction);
        return result;
    }

    public async Task<int> InsertAsync(Escola escola)
    {
        var parameters = new
        {
            UID = escola.Uid,
            NM_ESCOLA = escola.NomeCompleto,
            NM_ABREVIADO = escola.NomeAbreviado,
            ID_SITUACAO = escola.IdSituacao,
            CD_INEP = escola.CodigoINEP,
            DATA_CRIACAO = escola.DataCriacao,
            USUARIO_CRIACAO = escola.UsuarioCriacao
        };

        var result = await _dbContext.Connection.QuerySingleAsync<int>(EscolaQuery.Insert, parameters, transaction: _dbContext.Transaction);
        return result;
    }

    public async Task<int> UpdateAsync(Escola escola)
    {
        var parameters = new
        {
            ID = escola.Id,
            NM_ESCOLA = escola.NomeCompleto,
            NM_ABREVIADO = escola.NomeAbreviado,
            ID_SITUACAO = escola.IdSituacao,
            CD_INEP = escola.CodigoINEP,
            DATA_ATUALIZACAO = escola.DataAtualizacao,
            USUARIO_ATUALIZACAO = escola.UsuarioAtualizacao
        };
        var result = await _dbContext.Connection.ExecuteAsync(EscolaQuery.Update, parameters, transaction: _dbContext.Transaction);
        return result;
    }

    public async Task<int> DeleteAsync(Escola escola)
    {
        var parameters = new
        {
            ID = escola.Id,
            DATA_EXCLUSAO = escola.DataExclusao,
            USUARIO_EXCLUSAO = escola.UsuarioExclusao
        };
        var result = await _dbContext.Connection.ExecuteAsync(EscolaQuery.Delete, parameters, transaction: _dbContext.Transaction);
        return result;
    }
}
