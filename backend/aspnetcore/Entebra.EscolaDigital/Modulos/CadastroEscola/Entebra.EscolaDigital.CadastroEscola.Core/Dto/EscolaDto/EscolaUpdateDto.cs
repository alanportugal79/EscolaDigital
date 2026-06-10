using Entebra.EscolaDigital.CadastroEscola.Domain.Entities;

namespace Entebra.EscolaDigital.CadastroEscola.Core.Dto.EscolaDto;

public class EscolaUpdateDto
{    
    public Guid Uid { get; set; }
    public string NomeCompleto { get; set; }
    public string NomeAbreviado { get; set; }
    public int IdSituacao { get; set; }
    public string CodigoINEP { get; set; }    

    public Escola ToDomain() => new Escola
    {        
        Uid = Uid,
        NomeCompleto = NomeCompleto,
        NomeAbreviado = NomeAbreviado,
        IdSituacao = IdSituacao,
        CodigoINEP = CodigoINEP,                
        DataAtualizacao = DateTime.UtcNow,
    };
}
