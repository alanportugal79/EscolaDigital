namespace Entebra.EscolaDigital.CadastroEscola.Infrastructure.Persistence.Queries;

public static class SituacaoEscolaQuery
{
    private static readonly string TableName = "[ESCOLA].[TB_SITUACAO_ESCOLA]";
    private static readonly string Columns = @$"
        ID AS Id,
        DESCRICAO AS Descricao";

    public static readonly string GetAll = @$"SELECT {Columns} FROM {TableName}";
}
