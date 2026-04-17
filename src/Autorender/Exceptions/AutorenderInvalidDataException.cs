using System;

namespace Autorender.Exceptions;

public class AutorenderInvalidDataException : AutorenderException
{
    public AutorenderInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
