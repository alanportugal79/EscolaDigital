using Entebra.EscolaDigital.CadastroEscola.Core.Dto.EscolaDto;
using Entebra.EscolaDigital.CadastroEscola.Core.Interfaces;
using Entebra.EsolaDigital.Shared.Domain.Extensions.ResultExtentions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Entebra.EscolaDigital.CadastroEscola.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class EscolaController : ControllerBase
{
    private readonly IEscolaService _escolaService;

    public EscolaController(IEscolaService escolaService)
    {
        _escolaService = escolaService;
    }

    [HttpGet]
    [Route("get-teste")]
    public IActionResult GetTeste()
    {
        return Ok("Teste OK");
    }

    [HttpGet]    
    public async Task<IActionResult> GetAllAsync()
    {        
        var result = await _escolaService.GetAllAsync();
        return this.FromResult(result);
    }

    [HttpGet]
    [Route("{uid}")]
    public async Task<IActionResult> GetByUidAsync(Guid uid)
    {
        var result = await _escolaService.GetByUidAsync(uid);
        return this.FromResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> InsertAsync([FromBody] EscolaInsertDto escolaInsertDto)
    {
        var user = HttpContext.User;
        var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var usuarioCriacao = Guid.Parse(userId!);
        var result = await _escolaService.InsertAsync(escolaInsertDto, usuarioCriacao);
        return this.FromResult(result);
    }

    [HttpPut("{uid}")]
    public async Task<IActionResult> UpdateAsync(Guid uid, [FromBody] EscolaUpdateDto escolaUpdateDto)
    {
        var user = HttpContext.User;
        var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var usuarioAlteracao = Guid.Parse(userId!);
        var result = await _escolaService.UpdateAsync(uid, escolaUpdateDto, usuarioAlteracao);
        return this.FromResult(result);
    }

    [HttpDelete("{uid}")]
    public async Task<IActionResult> DeleteAsync(Guid uid)
    {
        var user = HttpContext.User;
        var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var usuarioDelete = Guid.Parse(userId!);
        var result = await _escolaService.DeleteAsync(uid, usuarioDelete);
        return this.FromResult(result);
    }


}
