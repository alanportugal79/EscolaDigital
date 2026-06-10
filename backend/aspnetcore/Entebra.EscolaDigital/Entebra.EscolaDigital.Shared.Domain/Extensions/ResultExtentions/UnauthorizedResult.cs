using Entebra.EsolaDigital.Shared.Domain.Enums;
using System.Net;

namespace Entebra.EsolaDigital.Shared.Domain.Extensions.ResultExtentions;

/// <summary>
/// Invalid result
/// </summary>
/// <typeparam name="T"></typeparam>
public class UnauthorizedResult<T> : Result<T>
{
    private readonly string _error;
    public UnauthorizedResult(string error)
    {
        _error = error;
    }

    public override bool IsSuccess => false;
    public override EResultType ResultType => EResultType.Unauthorized;
    public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;
    public override List<string> Errors => new() { _error ?? "ocorreu um erro" };
    public override IEnumerable<T> Data => default;
}
