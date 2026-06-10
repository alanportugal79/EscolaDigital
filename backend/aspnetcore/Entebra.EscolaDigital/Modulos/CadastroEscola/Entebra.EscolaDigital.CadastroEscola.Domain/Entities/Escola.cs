using Entebra.EscolaDigital.Shared.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entebra.EscolaDigital.CadastroEscola.Domain.Entities;

public class Escola : BaseEntity
{    
    public string NomeCompleto { get; set; }    
    public string NomeAbreviado { get; set; }
    public int IdSituacao { get; set; }
    public string CodigoINEP { get; set; }    

}
