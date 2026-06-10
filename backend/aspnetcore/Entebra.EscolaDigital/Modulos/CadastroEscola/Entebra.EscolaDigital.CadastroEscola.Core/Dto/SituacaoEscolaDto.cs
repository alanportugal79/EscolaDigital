using Entebra.EscolaDigital.CadastroEscola.Domain.Entities;

namespace Entebra.EscolaDigital.CadastroEscola.Core.Dto;

public class SituacaoEscolaDto
{
    public int Id { get; set; }
    public string Descricao { get; set; }

    public static SituacaoEscolaDto FromDomain(SituacaoEscola situacaoEscola) => new SituacaoEscolaDto
    {
        Id = situacaoEscola.Id,
        Descricao = situacaoEscola.Descricao
    };    
}
