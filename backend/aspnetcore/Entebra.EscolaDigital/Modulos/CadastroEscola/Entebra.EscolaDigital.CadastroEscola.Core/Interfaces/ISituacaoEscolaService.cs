using Entebra.EscolaDigital.CadastroEscola.Core.Dto;
using Entebra.EsolaDigital.Shared.Domain.Extensions.ResultExtentions;

namespace Entebra.EscolaDigital.CadastroEscola.Core.Interfaces;

public interface ISituacaoEscolaService
{
    Task<Result<SituacaoEscolaDto>> GetAllAsync();
}
