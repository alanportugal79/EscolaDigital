using System.ComponentModel.DataAnnotations.Schema;


namespace Habitat.EscolaDigital.Session.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    [Column("last_modified_by")]
    public Guid? LastModifiedBy { get; set; }

    [Column("date_created")]
    public DateTime DateCreated { get; set; } = DateTime.Now;

    [Column("date_updated")]
    public DateTime? DateUpdated { get; set; }

    [Column("date_deleted")]
    public DateTime? DateDeleted { get; set; }

    [Column("id_user")]
    public Guid IdUser { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; } = false;
}
