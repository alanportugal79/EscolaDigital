using Entebra.EsolaDigital.Shared.Domain.Enums;
using System.Net;

namespace Entebra.EsolaDigital.Shared.Domain.Extensions.ResultExtentions;

/// <summary>
/// Invalid result
/// </summary>
/// <typeparam name="T"></typeparam>
public class InvalidResult<T> : Result<T>
{
    private readonly string _error;
    public InvalidResult(string error)
    {
        _error = error;
    }

    public override bool IsSuccess => false;
    public override EResultType ResultType => EResultType.Invalid;
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    public override List<string> Errors => new() { _error ?? "ocorreu um erro" };
    public override IEnumerable<T> Data => default;
}
