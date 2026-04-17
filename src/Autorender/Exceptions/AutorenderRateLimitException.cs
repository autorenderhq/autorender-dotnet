using System.Net.Http;

namespace Autorender.Exceptions;

public class AutorenderRateLimitException : Autorender4xxException
{
    public AutorenderRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
