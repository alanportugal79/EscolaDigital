using Entebra.EscolaDigital.CadastroEscola.Core.Dto.UnidadeEscolarDto;
using Entebra.EscolaDigital.CadastroEscola.Domain.Interfaces;
using Entebra.EsolaDigital.Shared.Domain.Extensions.ResultExtentions;

namespace Entebra.EscolaDigital.CadastroEscola.Core.Services;

public class UnidadeService
{
    private readonly IUnidadeRepository _unidadeRepository;

    public UnidadeService(IUnidadeRepository unidadeRepository)
    {
        _unidadeRepository = unidadeRepository;
    }

    public async Task<Result<UnidadeEscolarDto>> GetAllAsync()
    {
        var unidades = await _unidadeRepository.GetAllAsync();
        var unidadesDto = unidades.Select(UnidadeEscolarDto.FromDomain);
        return new SuccessResult<UnidadeEscolarDto>(unidadesDto);
    }

    public async Task<Result<UnidadeEscolarDto>> GetByIdAsync(int id)
    {
        var unidade = await _unidadeRepository.GetByIdAsync(id);
        if (unidade == null)
        {
            return new NotFoundResult<UnidadeEscolarDto>("Unidade Escolar não encontrado");
        }
        var unidadeDto = UnidadeEscolarDto.FromDomain(unidade);
        return new SuccessResult<UnidadeEscolarDto>(unidadeDto);
    }

    public async Task<Result<UnidadeEscolarDto>> GetByUidAsync(Guid uid)
    {
        var unidade = await _unidadeRepository.GetByUidAsync(uid);
        if (unidade == null)
        {
            return new NotFoundResult<UnidadeEscolarDto>("Unidade Escolar não encontrado");
        }
        var unidadeDto = UnidadeEscolarDto.FromDomain(unidade);
        return new SuccessResult<UnidadeEscolarDto>(unidadeDto);
    }

    public async Task<Result<UnidadeEscolarDto>> GetByIdEscolaAsync(int idEscola)
    {
        var unidades = await _unidadeRepository.GetByIdEscolaAsync(idEscola);        
        var unidadesDto =   unidades.Select(UnidadeEscolarDto.FromDomain);
        return new SuccessResult<UnidadeEscolarDto>(unidadesDto);
    }

   /* public async Task<Result<Guid>> InsertAsync(UnidadeEscolarDto unidadeDto)
    {
        var unidade = unidadeDto.ToDomain();
        unidade.Uid = Guid.NewGuid();
        var id = await _unidadeRepository.InsertAsync(unidade);        
        return new SuccessResult<Guid>(unidade.Uid);
    }*/
}
