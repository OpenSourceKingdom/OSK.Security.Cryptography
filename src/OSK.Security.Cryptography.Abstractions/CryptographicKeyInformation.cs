using System;

namespace OSK.Security.Cryptography.Abstractions
{
    public abstract class CryptographicKeyInformation : IDisposable
    {
        public abstract PublicKeyInformation GetPublicKeyInformation();
        public abstract void Dispose();
    }
}
