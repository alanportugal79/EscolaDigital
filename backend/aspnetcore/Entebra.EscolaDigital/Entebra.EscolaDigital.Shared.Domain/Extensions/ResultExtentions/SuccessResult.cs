using Entebra.EsolaDigital.Shared.Domain.Enums;
using System.Net;

namespace Entebra.EsolaDigital.Shared.Domain.Extensions.ResultExtentions;

/// <summary>
/// Success result
/// </summary>
public class SuccessResult<T> : Result<T>
{
    private readonly IEnumerable<T> _data;
    public SuccessResult(IEnumerable<T> data)
    {
        _data = data;
    }

    public SuccessResult(T data)
    {
        _data = new[] { data };
    }

    public override bool IsSuccess => true;
    public override EResultType ResultType => EResultType.Ok;
    public override HttpStatusCode StatusCode => HttpStatusCode.OK;
    public override List<string> Errors => new();
    public override IEnumerable<T> Data => _data;
    public int TotalRecords { get; set; }
}
