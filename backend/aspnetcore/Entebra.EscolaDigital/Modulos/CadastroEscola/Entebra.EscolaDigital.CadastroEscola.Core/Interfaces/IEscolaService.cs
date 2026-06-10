using Entebra.EscolaDigital.CadastroEscola.Core.Dto.EscolaDto;
using Entebra.EsolaDigital.Shared.Domain.Extensions.ResultExtentions;

namespace Entebra.EscolaDigital.CadastroEscola.Core.Interfaces;

public interface IEscolaService
{
    Task<Result<EscolaDto>> GetAllAsync();
    Task<Result<EscolaDto>> GetByIdAsync(int id);
    Task<Result<EscolaDto>> GetByUidAsync(Guid uid);
    Task<Result<EscolaDto>> InsertAsync(EscolaInsertDto escolaIsertDto, Guid usuarioCriacao);
    Task<Result<EscolaDto>> UpdateAsync(Guid uid, EscolaUpdateDto escolaUpdateDto, Guid usuarioAutalizacao);
    Task<Result<EscolaDeleteResultDto>> DeleteAsync(Guid uid, Guid usuarioExclusao);
}
