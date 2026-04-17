using System;
using System.Net.Http;

namespace Autorender.Exceptions;

public class AutorenderIOException : AutorenderException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public AutorenderIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
