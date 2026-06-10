namespace Entebra.EscolaDigital.CadastroEscola.Infrastructure.Persistence.Queries;

public static class UnidadeQuery
{
    private static readonly string TableName = "[ESCOLA].[TB_UNIDADE]";
    private static readonly string Columns = @"
       [ID] AS Id
      ,[UID] AS Uid
      ,[ID_ESCOLA] AS IdEscola
      ,[NM_UNIDADE] AS NomeUnidade
      ,[FL_PRINCIPAL] AS FlagPrincipal
      ,[ID_SITUACAO] AS IdSituacao
      ,[CEP] AS Cep
      ,[LOGRADOURO] AS Logradouro
      ,[NUMERO] AS Numero
      ,[COMPLEMENTO] AS Complemento
      ,[BAIRRO] AS Bairro
      ,[CIDADE] AS Cidade
      ,[ESTADO] AS Estado
      ,[DATA_CRIACAO] AS DataCriacao
      ,[USUARIO_CRIACAO] AS UsuarioCriacao
      ,[DATA_ATUALIZACAO] AS DataAtualizacao
      ,[USUARIO_ATUALIZACAO] AS UsuarioAtualizacao
      ,[DATA_EXCLUSAO] AS DataExclusao
      ,[USUARIO_EXCLUSAO] AS UsuarioExclusao";

    private static readonly string BaseQuery = @$"SELECT {Columns} FROM {TableName}";

    public static readonly string GetAll = @$"{BaseQuery} WHERE DATA_EXCLUSAO IS NULL";
    public static readonly string GetById = @$"{BaseQuery} WHERE ID = @ID AND DATA_EXCLUSAO IS NULL";
    public static readonly string GetByUid = @$"{BaseQuery} WHERE UID = @UID AND DATA_EXCLUSAO IS NULL";
    public static readonly string GetByIdEscola = @$"{BaseQuery} WHERE ID_ESCOLA = @ID_ESCOLA AND DATA_EXCLUSAO IS NULL";

    public static readonly string Insert = @$"
        INSERT INTO {TableName} 
        (UID, ID_ESCOLA, NM_UNIDADE, FL_PRINCIPAL, ID_SITUACAO, CEP, LOGRADOURO, NUMERO, COMPLEMENTO, BAIRRO, CIDADE, ESTADO, DATA_CRIACAO, USUARIO_CRIACAO)
        VALUES 
        (@UID, @ID_ESCOLA, @NM_UNIDADE, @FL_PRINCIPAL, @ID_SITUACAO, @CEP, @LOGRADOURO, @NUMERO, @COMPLEMENTO, @BAIRRO, @CIDADE, @ESTADO, @DATA_CRIACAO, @USUARIO_CRIACAO);
        SELECT CAST(SCOPE_IDENTITY() as int)";

    public static readonly string Update = @$"
        UPDATE {TableName}
           SET [ID_ESCOLA] = @ID_ESCOLA
              ,[NM_UNIDADE] = @NM_UNIDADE
              ,[FL_PRINCIPAL] = @FL_PRINCIPAL
              ,[ID_SITUACAO] = @ID_SITUACAO
              ,[CEP] = @CEP
              ,[LOGRADOURO] = @LOGRADOURO
              ,[NUMERO] = @NUMERO
              ,[COMPLEMENTO] = @COMPLEMENTO
              ,[BAIRRO] = @BAIRRO
              ,[CIDADE] = @CIDADE
              ,[ESTADO] = @ESTADO              
              ,[DATA_ATUALIZACAO] = @DATA_ATUALIZACAO
              ,[USUARIO_ATUALIZACAO] = @USUARIO_ATUALIZACAO              
         WHERE [ID] = @ID";

    public static readonly string Delete = @$"
        UPDATE {TableName} 
        SET DATA_EXCLUSAO = @DATA_EXCLUSAO, USUARIO_EXCLUSAO = @USUARIO_EXCLUSAO
        WHERE ID = @ID";

    
}
