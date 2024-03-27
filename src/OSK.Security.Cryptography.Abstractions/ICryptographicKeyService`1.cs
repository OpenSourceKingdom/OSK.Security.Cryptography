using System;

namespace OSK.Security.Cryptography.Abstractions
{
    public interface ICryptographicKeyService<TKeyInformation> : ICryptographicKeyService, IDisposable
        where TKeyInformation : ICryptographicKeyInformation
    {
        TKeyInformation KeyInformation { get; }
    }
}
