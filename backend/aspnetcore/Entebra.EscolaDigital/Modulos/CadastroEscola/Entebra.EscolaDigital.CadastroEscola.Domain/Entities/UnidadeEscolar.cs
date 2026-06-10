using Entebra.EscolaDigital.Shared.Domain.Entities;

namespace Entebra.EscolaDigital.CadastroEscola.Domain.Entities;

public class UnidadeEscolar : BaseEntity
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
}
