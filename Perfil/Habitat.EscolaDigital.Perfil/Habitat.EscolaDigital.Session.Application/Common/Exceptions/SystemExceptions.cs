using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habitat.EscolaDigital.Session.Application.Common.Exceptions;

public class BadRequestException : Exception
{
    public string[] Errors { get; set; }

    public BadRequestException(string message) : base(message)
    {
    }

    public BadRequestException(string[] errors) : base("Vários erros ocorreu. Veja o detalhe do erro.")
    {
        Errors = errors;
    }
}

public class NoDataFoundException : Exception
{
    public NoDataFoundException(string message) : base(message)
    {
    }
}

public class SocketException : Exception
{
    public SocketException(string message) : base(message)
    {
    }
}
public class UserAlreadyExistsException : Exception
{
    public UserAlreadyExistsException() : base("Usuário já existe.")
    {
    }
}
