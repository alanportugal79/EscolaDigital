using Entebra.EscolaDigital.CadastroEscola.Domain.Interfaces;
using Entebra.EscolaDigital.CadastroEscola.Core.Interfaces;
using Entebra.EsolaDigital.Shared.Domain.Extensions.ResultExtentions;
using Entebra.EsolaDigital.Shared.Infrastructure.Exceptions;
using Dapper;
using Entebra.EscolaDigital.CadastroEscola.Core.Dto.EscolaDto;

namespace Entebra.EscolaDigital.CadastroEscola.Core.Services;

public class EscolaService: IEscolaService
{
    private readonly IEscolaRepository _escolaRepository;

    public EscolaService(IEscolaRepository escolaRepository)
    {
        _escolaRepository = escolaRepository;
    }

    public async Task<Result<EscolaDto>> GetAllAsync()
    {
        var escolas =  await _escolaRepository.GetAllAsync();        
        var escolaDtos = escolas.Select(EscolaDto.FromDomain).AsList();
        return new SuccessResult<EscolaDto>(escolaDtos);
    } 
    
    public async Task<Result<EscolaDto>> GetByIdAsync(int id)
    {
        var escola = await _escolaRepository.GetByIdAsync(id);

        if (escola == null)
        {
            return new NotFoundResult<EscolaDto>("Escola não econtrado");
        }

        var escolaDto = EscolaDto.FromDomain(escola);
        return new SuccessResult<EscolaDto>(escolaDto);
    }

    public async Task<Result<EscolaDto>> GetByUidAsync(Guid uid)
    {
        var escola = await _escolaRepository.GetByUidAsync(uid);            

        if (escola == null)
        {
            return new NotFoundResult<EscolaDto>("Escola não econtrado");
        }

        var escolaDto = EscolaDto.FromDomain(escola);
        return new SuccessResult<EscolaDto>(escolaDto);
    }

    public async Task<Result<EscolaDto>> InsertAsync(EscolaInsertDto escolaDto, Guid usuarioCriacao)
    {
        var escolaInsert = escolaDto.ToDomain();        
        escolaInsert.UsuarioCriacao = usuarioCriacao;
        
        var idEscola = await _escolaRepository.InsertAsync(escolaInsert);
        var escola = await _escolaRepository.GetByIdAsync(idEscola)
            ?? throw new CustomException("Erro ao criar escola", null, System.Net.HttpStatusCode.BadRequest);        

        return new CreatedResult<EscolaDto>(EscolaDto.FromDomain(escola));
    }

    public async Task<Result<EscolaDto>> UpdateAsync(Guid uid, EscolaUpdateDto escolaUpdateDto, Guid usuarioAutalizacao)
    {        
        var escola = await _escolaRepository.GetByUidAsync(uid);

        if (escola == null)
        {
            return new NotFoundResult<EscolaDto>("Escola não econtrado");
        }

        var escolaUpdate = escolaUpdateDto.ToDomain();
        escolaUpdate.Id = escola.Id;
        escolaUpdate.UsuarioAtualizacao = usuarioAutalizacao;

        await _escolaRepository.UpdateAsync(escolaUpdate);
        escola = await _escolaRepository.GetByUidAsync(uid);

        return new SuccessResult<EscolaDto>(EscolaDto.FromDomain(escola!));
    }

    public async Task<Result<EscolaDeleteResultDto>> DeleteAsync(Guid uid, Guid usuarioExclusao)
    {
        var escola = await _escolaRepository.GetByUidAsync(uid);

        if (escola == null)
        {
            return new NotFoundResult<EscolaDeleteResultDto>("Escola não econtrado");
        }

        escola.DataExclusao = DateTime.UtcNow;
        escola.UsuarioExclusao = usuarioExclusao;

        await _escolaRepository.DeleteAsync(escola);        

        return new SuccessResult<EscolaDeleteResultDto>(EscolaDeleteResultDto.FromDomain(escola));
    }

}
