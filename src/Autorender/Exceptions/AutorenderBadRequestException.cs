using System.Net.Http;

namespace Autorender.Exceptions;

public class AutorenderBadRequestException : Autorender4xxException
{
    public AutorenderBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
