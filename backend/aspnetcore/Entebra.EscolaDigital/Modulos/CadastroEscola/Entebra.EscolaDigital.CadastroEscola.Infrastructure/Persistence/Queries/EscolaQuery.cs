namespace Entebra.EscolaDigital.CadastroEscola.Infrastructure.Persistence.Queries;

public static class EscolaQuery
{
    private static readonly string TableName = "[ESCOLA].[TB_ESCOLA]";
    private static readonly string Columns = @"
        ID as Id
        , UID as Uid
        , NM_ESCOLA as NomeCompleto
        , NM_ABREVIADO as NomeAbreviado
        , ID_SITUACAO as IdSituacao
        , CD_INEP as CodigoINEP
        , DATA_CRIACAO as DataCriacao
        , USUARIO_CRIACAO as UsuarioCriacao
        , DATA_ATUALIZACAO as DataAtualizacao
        , USUARIO_ATUALIZACAO as UsuarioAtualizacao
        , DATA_EXCLUSAO as DataExclusao
        , USUARIO_EXCLUSAO as UsuarioExclusao";

    private static readonly string BaseQuery = @$"SELECT {Columns} FROM {TableName}";

    public static readonly string GetAll = @$"{BaseQuery} WHERE DATA_EXCLUSAO IS NULL";
    public static readonly string GetById = @$"{BaseQuery} WHERE ID = @ID AND DATA_EXCLUSAO IS NULL";
    public static readonly string GetByUid = @$"{BaseQuery} WHERE UID = @UID AND DATA_EXCLUSAO IS NULL";    

    public static readonly string Insert = @$"
        INSERT INTO {TableName} (UID, NM_ESCOLA, NM_ABREVIADO, ID_SITUACAO, CD_INEP, DATA_CRIACAO, USUARIO_CRIACAO)
        VALUES (@UID, @NM_ESCOLA, @NM_ABREVIADO, @ID_SITUACAO, @CD_INEP, @DATA_CRIACAO, @USUARIO_CRIACAO);
        SELECT CAST(SCOPE_IDENTITY() as int)";
    
    public static readonly string Update = @$"
        UPDATE {TableName} 
           SET NM_ESCOLA = @NM_ESCOLA
             , NM_ABREVIADO = @NM_ABREVIADO
             , ID_SITUACAO = @ID_SITUACAO
             , CD_INEP = @CD_INEP
             , DATA_ATUALIZACAO = @DATA_ATUALIZACAO
             , USUARIO_ATUALIZACAO = @USUARIO_ATUALIZACAO
         WHERE ID = @ID";
    
    public static readonly string Delete = @$"
        UPDATE {TableName} 
           SET DATA_EXCLUSAO = @DATA_EXCLUSAO
             , USUARIO_EXCLUSAO = @USUARIO_EXCLUSAO
         WHERE ID = @ID";
}
