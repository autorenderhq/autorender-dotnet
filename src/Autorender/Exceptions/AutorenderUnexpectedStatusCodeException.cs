using System.Net.Http;

namespace Autorender.Exceptions;

public class AutorenderUnexpectedStatusCodeException : AutorenderApiException
{
    public AutorenderUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
