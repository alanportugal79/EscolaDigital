using Entebra.EscolaDigital.CadastroEscola.Domain.Entities;

namespace Entebra.EscolaDigital.CadastroEscola.Domain.Interfaces;

public interface ISituacaoEscolaRepository
{
    Task<IEnumerable<SituacaoEscola>> GetAllAsync();
}
