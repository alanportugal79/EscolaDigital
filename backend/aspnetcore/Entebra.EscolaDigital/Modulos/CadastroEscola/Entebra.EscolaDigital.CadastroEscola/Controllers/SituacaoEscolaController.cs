using Entebra.EscolaDigital.CadastroEscola.Core.Interfaces;
using Entebra.EsolaDigital.Shared.Domain.Extensions.ResultExtentions;
using Microsoft.AspNetCore.Mvc;

namespace Entebra.EscolaDigital.CadastroEscola.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SituacaoEscolaController : ControllerBase
{
    private readonly ISituacaoEscolaService _situacaoEscolaService;

    public SituacaoEscolaController(ISituacaoEscolaService situacaoEscolaService)
    {
        _situacaoEscolaService = situacaoEscolaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _situacaoEscolaService.GetAllAsync();
        return this.FromResult(result);
    }
}
