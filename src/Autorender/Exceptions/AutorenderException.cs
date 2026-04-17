using System;
using System.Net.Http;

namespace Autorender.Exceptions;

public class AutorenderException : Exception
{
    public AutorenderException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected AutorenderException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
