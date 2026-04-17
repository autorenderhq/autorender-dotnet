using System.Net.Http;

namespace Autorender.Exceptions;

public class AutorenderForbiddenException : Autorender4xxException
{
    public AutorenderForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
