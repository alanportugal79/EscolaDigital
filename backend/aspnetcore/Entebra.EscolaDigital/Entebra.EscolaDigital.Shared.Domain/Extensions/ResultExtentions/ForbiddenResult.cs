using Entebra.EsolaDigital.Shared.Domain.Enums;
using System.Net;

namespace Entebra.EsolaDigital.Shared.Domain.Extensions.ResultExtentions;

/// <summary>
/// Invalid result
/// </summary>
/// <typeparam name="T"></typeparam>
public class ForbiddenResult<T> : Result<T>
{
    private readonly string _error;
    public ForbiddenResult(string error)
    {
        _error = error;
    }

    public override bool IsSuccess => false;
    public override EResultType ResultType => EResultType.Forbidden;
    public override HttpStatusCode StatusCode => HttpStatusCode.Forbidden;
    public override List<string> Errors => new() { _error ?? "ocorreu um erro" };
    public override IEnumerable<T> Data => default;
}
