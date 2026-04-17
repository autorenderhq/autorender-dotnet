using System.Net.Http;

namespace Autorender.Exceptions;

public class AutorenderUnauthorizedException : Autorender4xxException
{
    public AutorenderUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
