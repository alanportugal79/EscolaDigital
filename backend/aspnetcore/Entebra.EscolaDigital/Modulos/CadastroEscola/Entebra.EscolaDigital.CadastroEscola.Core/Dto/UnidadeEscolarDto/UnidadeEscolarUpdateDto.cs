using Entebra.EscolaDigital.CadastroEscola.Domain.Entities;

namespace Entebra.EscolaDigital.CadastroEscola.Core.Dto.UnidadeEscolarDto;

public class UnidadeEscolarUpdateDto
{
    public Guid Uid { get; set; }
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
    public UnidadeEscolar ToDomain() => new UnidadeEscolar
    {
        Uid = Uid,
        IdEscola = IdEscola,
        NomeUnidade = NomeUnidade,
        FlagPrincipal = FlagPrincipal,
        IdSituacao = IdSituacao,
        Cep = Cep,
        Logradouro = Logradouro,
        Numero = Numero,
        Complemento = Complemento,
        Bairro = Bairro,
        Cidade = Cidade,
        Estado = Estado,
        DataAtualizacao = DateTime.UtcNow,
    };
}
