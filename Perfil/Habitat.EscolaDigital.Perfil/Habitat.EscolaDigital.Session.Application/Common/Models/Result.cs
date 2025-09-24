using System;
using System.Collections.Generic;
using System.Linq;
namespace Habitat.EscolaDigital.Session.Application.Common.Models;

public class Result<T>
{
    private readonly IEnumerable<T> _data;
    private readonly int _recordCount;
    private readonly int _totalPage;
    private readonly int _currentPage;
    private readonly int _recordPerPage;
    
    public Result(IEnumerable<T> data, int recordCount, int totalPage, int currentPage, int recordPerPage)
    {
        _data = data;
        _recordCount = recordCount;
        _totalPage = totalPage;
        _currentPage = currentPage;
        _recordPerPage = recordPerPage;
    }    

    public IEnumerable<T> Data => _data;
    public int RecordCount => _recordCount;
    public int TotalPage => _totalPage;
    public int CurrentPage => _currentPage;
    public int RecordPerPage => _recordPerPage;

}
