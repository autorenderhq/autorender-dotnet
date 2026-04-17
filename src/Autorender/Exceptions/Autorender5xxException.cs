using System.Net.Http;

namespace Autorender.Exceptions;

public class Autorender5xxException : AutorenderApiException
{
    public Autorender5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
