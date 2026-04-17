using System.Net.Http;

namespace Autorender.Exceptions;

public class Autorender4xxException : AutorenderApiException
{
    public Autorender4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
