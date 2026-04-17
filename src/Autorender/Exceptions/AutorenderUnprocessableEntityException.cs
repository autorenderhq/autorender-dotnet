using System.Net.Http;

namespace Autorender.Exceptions;

public class AutorenderUnprocessableEntityException : Autorender4xxException
{
    public AutorenderUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
