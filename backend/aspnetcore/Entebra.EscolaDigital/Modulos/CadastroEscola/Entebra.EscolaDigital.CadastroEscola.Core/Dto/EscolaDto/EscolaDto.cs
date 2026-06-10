using Entebra.EscolaDigital.CadastroEscola.Domain.Entities;

namespace Entebra.EscolaDigital.CadastroEscola.Core.Dto.EscolaDto;

public class EscolaDto
{    
    public Guid? Uid { get; set; }
    public string NomeCompleto { get; set; }
    public string NomeAbreviado { get; set; }
    public int IdSituacao { get; set; }
    public string CodigoINEP { get; set; }
    public DateTime DataCriacao { get; set; }
    public Guid UsuarioCriacao { get; set; }
    public DateTime? DataAlteracao { get; set; }
    public Guid? UsuarioAlteracao { get; set; }

    public static EscolaDto FromDomain(Escola escola) => new EscolaDto
    {        
        Uid = escola.Uid,
        NomeCompleto = escola.NomeCompleto,
        NomeAbreviado = escola.NomeAbreviado,
        IdSituacao = escola.IdSituacao,
        CodigoINEP = escola.CodigoINEP,
        DataCriacao = escola.DataCriacao,
        UsuarioCriacao = escola.UsuarioCriacao,
        DataAlteracao = escola.DataAtualizacao,
        UsuarioAlteracao = escola.UsuarioAtualizacao
    };    
}
