using Entebra.EsolaDigital.Shared.Domain.Enums;
using System.Net;


namespace Entebra.EsolaDigital.Shared.Domain.Extensions.ResultExtentions;

public class CreatedResult<T> : Result<T>
{
    private readonly T _data;
    public CreatedResult(T data)
    {
        _data = data;
    }        

    public override bool IsSuccess => true;
    public override EResultType ResultType => EResultType.Created;
    public override HttpStatusCode StatusCode => HttpStatusCode.Created;
    public override List<string> Errors => new();
    public override IEnumerable<T> Data => new List<T>(){ _data };
}
