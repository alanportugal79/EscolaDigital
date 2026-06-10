using Entebra.EsolaDigital.Shared.Domain.Enums;
using System.Net;

namespace Entebra.EsolaDigital.Shared.Domain.Extensions.ResultExtentions;

/// <summary>
/// Not found result
/// </summary>
/// <typeparam name="T"></typeparam>
public class NotFoundResult<T> : Result<T>
{
    private readonly string _error;
    public NotFoundResult(string error)
    {
        _error = error;
    }

    public override bool IsSuccess => false;
    public override EResultType ResultType => EResultType.NotFound;
    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    public override List<string> Errors => new() { _error ?? "objeto não encontrado" };
    public override IEnumerable<T> Data => default;
}
