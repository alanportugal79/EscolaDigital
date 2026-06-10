using Dapper;
using Entebra.EscolaDigital.CadastroEscola.Domain.Entities;
using Entebra.EscolaDigital.CadastroEscola.Domain.Interfaces;
using Entebra.EscolaDigital.CadastroEscola.Infrastructure.Persistence.Queries;
using Entebra.EscolaDigital.Shared.Infrastructure.Persistence;

namespace Entebra.EscolaDigital.CadastroEscola.Infrastructure.Persistence.Repositories;

public class UnidadeRepository : IUnidadeRepository
{
    private readonly ModuleDbContext _dbContext;

    public UnidadeRepository(ModuleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<UnidadeEscolar>> GetAllAsync()
    {
        var result = await _dbContext.Connection.QueryAsync<UnidadeEscolar>(UnidadeQuery.GetAll, transaction: _dbContext.Transaction);
        return result;
    }

    public async Task<UnidadeEscolar?> GetByIdAsync(int id)
    {
        var result = await _dbContext.Connection.QuerySingleOrDefaultAsync<UnidadeEscolar>(UnidadeQuery.GetById, new { ID = id }, transaction: _dbContext.Transaction);
        return result;
    }

    public async Task<UnidadeEscolar?> GetByUidAsync(Guid uid)
    {
        var result = await _dbContext.Connection.QuerySingleOrDefaultAsync<UnidadeEscolar>(UnidadeQuery.GetByUid, new { UID = uid }, transaction: _dbContext.Transaction);
        return result;
    }

    public async Task<IEnumerable<UnidadeEscolar>> GetByIdEscolaAsync(int idEscola)
    {
        var result = await _dbContext.Connection.QueryAsync<UnidadeEscolar>(UnidadeQuery.GetByUid, new { ID_ESCOLA = idEscola }, transaction: _dbContext.Transaction);
        return result;
    }

    public async Task<int> InsertAsync(UnidadeEscolar unidade)
    {
        var parameters = new
        {
            UID = unidade.Uid,
            ID_ESCOLA = unidade.IdEscola,
            NM_UNIDADE = unidade.NomeUnidade,
            FL_PRINCIPAL = unidade.FlagPrincipal,
            ID_SITUACAO = unidade.IdSituacao,
            CEP = unidade.Cep,
            LOGRADOURO = unidade.Logradouro,
            NUMERO = unidade.Numero,
            COMPLEMENTO = unidade.Complemento,
            BAIRRO = unidade.Bairro,
            CIDADE = unidade.Cidade,
            ESTADO = unidade.Estado,
            DATA_CRIACAO = unidade.DataCriacao,
            USUARIO_CRIACAO = unidade.UsuarioCriacao
        };
        var result = await _dbContext.Connection.QuerySingleAsync<int>(UnidadeQuery.Insert, parameters, transaction: _dbContext.Transaction);
        return result;
    }
    public async Task<int> UpdateAsync(UnidadeEscolar unidade)
    {
        var parameters = new
        {
            ID = unidade.Id,
            ID_ESCOLA = unidade.IdEscola,
            NM_UNIDADE = unidade.NomeUnidade,
            FL_PRINCIPAL = unidade.FlagPrincipal,
            ID_SITUACAO = unidade.IdSituacao,
            CEP = unidade.Cep,
            LOGRADOURO = unidade.Logradouro,
            NUMERO = unidade.Numero,
            COMPLEMENTO = unidade.Complemento,
            BAIRRO = unidade.Bairro,
            CIDADE = unidade.Cidade,
            ESTADO = unidade.Estado,
            DATA_ATUALIZACAO = unidade.DataAtualizacao,
            USUARIO_ATUALIZACAO = unidade.UsuarioAtualizacao
        };
        var result = await _dbContext.Connection.ExecuteAsync(UnidadeQuery.Update, parameters, transaction: _dbContext.Transaction);
        return result;
    }

    public async Task<int> DeleteAsync(int id, DateTime dataExclusao, string usuarioExclusao)
    {
        var parameters = new
        {
            ID = id,
            DATA_EXCLUSAO = dataExclusao,
            USUARIO_EXCLUSAO = usuarioExclusao
        };
        var result = await _dbContext.Connection.ExecuteAsync(UnidadeQuery.Delete, parameters, transaction: _dbContext.Transaction);
        return result;
    }

}
