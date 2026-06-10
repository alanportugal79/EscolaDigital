using Entebra.EscolaDigital.CadastroEscola.Domain.Entities;

namespace Entebra.EscolaDigital.CadastroEscola.Domain.Interfaces;

public interface IUnidadeRepository
{
    Task<IEnumerable<UnidadeEscolar>> GetAllAsync();
    Task<UnidadeEscolar?> GetByIdAsync(int id);
    Task<UnidadeEscolar?> GetByUidAsync(Guid uid);
    Task<IEnumerable<UnidadeEscolar>> GetByIdEscolaAsync(int idEscola);
    Task<int> InsertAsync(UnidadeEscolar unidade);
    Task<int> UpdateAsync(UnidadeEscolar unidade);
    Task<int> DeleteAsync(int id, DateTime dataExclusao, string usuarioExclusao);
}
