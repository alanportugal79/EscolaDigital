using Entebra.EscolaDigital.CadastroEscola.Domain.Entities;

namespace Entebra.EscolaDigital.CadastroEscola.Core.Dto.UnidadeEscolarDto;

public class UnidadeEscolarDto
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
    public DateTime DataCriacao { get; set; }
    public Guid UsuarioCriacao { get; set; }
    public DateTime? DataAlteracao { get; set; }
    public Guid? UsuarioAlteracao { get; set; }


    public static UnidadeEscolarDto FromDomain(UnidadeEscolar unidadeEscolar) => new UnidadeEscolarDto
    {        
        Uid = unidadeEscolar.Uid,
        IdEscola = unidadeEscolar.IdEscola,
        NomeUnidade = unidadeEscolar.NomeUnidade,
        FlagPrincipal = unidadeEscolar.FlagPrincipal,
        IdSituacao = unidadeEscolar.IdSituacao,
        Cep = unidadeEscolar.Cep,
        Logradouro = unidadeEscolar.Logradouro,
        Numero = unidadeEscolar.Numero,
        Complemento = unidadeEscolar.Complemento,
        Bairro = unidadeEscolar.Bairro,
        Cidade = unidadeEscolar.Cidade,
        Estado = unidadeEscolar.Estado,
        DataCriacao = unidadeEscolar.DataCriacao,
        UsuarioCriacao = unidadeEscolar.UsuarioCriacao,
        DataAlteracao = unidadeEscolar.DataAtualizacao,
        UsuarioAlteracao = unidadeEscolar.UsuarioAtualizacao
    };    

}
