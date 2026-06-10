using Entebra.EscolaDigital.CadastroEscola.Domain.Entities;

namespace Entebra.EscolaDigital.CadastroEscola.Core.Dto.EscolaDto;

public class EscolaDeleteResultDto
{
    public Guid Uid { get; set; }
    public DateTime DataExclusao { get; set; }
    public Guid UsuarioExlcusao { get; set; }

    public static EscolaDeleteResultDto FromDomain(Escola escola) => new EscolaDeleteResultDto
    {
        Uid = escola.Uid,
        DataExclusao = escola.DataExclusao ?? DateTime.UtcNow,
        UsuarioExlcusao = escola.UsuarioExclusao ?? Guid.Empty
    };
}
