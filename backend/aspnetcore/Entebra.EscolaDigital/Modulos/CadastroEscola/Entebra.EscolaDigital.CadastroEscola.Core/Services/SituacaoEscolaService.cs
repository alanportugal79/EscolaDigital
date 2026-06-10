using Entebra.EscolaDigital.CadastroEscola.Core.Dto;
using Entebra.EscolaDigital.CadastroEscola.Core.Interfaces;
using Entebra.EscolaDigital.CadastroEscola.Domain.Interfaces;
using Entebra.EsolaDigital.Shared.Domain.Extensions.ResultExtentions;

namespace Entebra.EscolaDigital.CadastroEscola.Core.Services;

public class SituacaoEscolaService : ISituacaoEscolaService
{
    private readonly ISituacaoEscolaRepository _situacaoEscolaRepository;

    public SituacaoEscolaService(ISituacaoEscolaRepository situacaoEscolaRepository)
    {
        _situacaoEscolaRepository = situacaoEscolaRepository;
    }

    public async Task<Result<SituacaoEscolaDto>> GetAllAsync()
    {
        var situacoes =  await _situacaoEscolaRepository.GetAllAsync();
        var situacaoDtos = situacoes.Select(SituacaoEscolaDto.FromDomain);
        return new SuccessResult<SituacaoEscolaDto>(situacaoDtos);
    }
}
