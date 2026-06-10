
namespace Entebra.EscolaDigital.Shared.Domain.Entities;

public class BaseEntity
{
    /* Identificação */
    public int Id { get; set; }
    public Guid Uid { get; set; }

    
    /* Criação */
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    public Guid UsuarioCriacao { get; set; }
    
    
    /* Atualizacao */
    public DateTime? DataAtualizacao { get; set; }
    public Guid? UsuarioAtualizacao { get; set; }
    
    
    /* Exclusão */
    public DateTime? DataExclusao { get; set; }
    public Guid? UsuarioExclusao { get; set; }
    
    


}
