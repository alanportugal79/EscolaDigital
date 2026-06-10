using Entebra.EscolaDigital.CadastroEscola.Domain.Entities;

namespace Entebra.EscolaDigital.CadastroEscola.Core.Dto.UnidadeEscolarDto;

public class UnidadeEscolarInsertDto
{
    public int IdEscola { get; set; }
    public string NomeUnidade { get; set; }
    public bool FlagPrincipal { get; set; }
    public int IdSituacao { get; set; }
    public string? Cep { get; set; }
    public string? Logradouro { get; set; }
    public string? Numero { get; set; }
    public string? Complemento { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; }
    public string? Estado { get; set; }    

    public UnidadeEscolar ToDomain => new UnidadeEscolar
    {        
        IdEscola = this.IdEscola,
        NomeUnidade = this.NomeUnidade,
        FlagPrincipal = this.FlagPrincipal,
        IdSituacao = this.IdSituacao,
        Cep = this.Cep,
        Logradouro = this.Logradouro,
        Numero = this.Numero,
        Complemento = this.Complemento,
        Bairro = this.Bairro,
        Cidade = this.Cidade,
        Estado = this.Estado,
        DataCriacao = DateTime.UtcNow
    };
}
