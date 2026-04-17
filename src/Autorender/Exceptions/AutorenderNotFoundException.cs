using System.Net.Http;

namespace Autorender.Exceptions;

public class AutorenderNotFoundException : Autorender4xxException
{
    public AutorenderNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
