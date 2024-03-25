using System;

namespace OSK.Security.Cryptography.Exceptions
{
    public class KeySizeException : Exception
    {
        public KeySizeException(string message)
            : base(message)
        {
        }
    }
}
