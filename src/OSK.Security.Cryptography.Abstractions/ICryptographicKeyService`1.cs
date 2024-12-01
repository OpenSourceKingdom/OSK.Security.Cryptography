using System;
using OSK.Hexagonal.MetaData;

namespace OSK.Security.Cryptography.Abstractions
{
    [HexagonalPort(HexagonalPort.Secondary)]
    public interface ICryptographicKeyService<TKeyInformation> : ICryptographicKeyService, IDisposable
        where TKeyInformation : ICryptographicKeyInformation
    {
        /// <summary>
        /// The key information to use with encryption or decryption. The data should be destroyed when the service is disposed.
        /// </summary>
        TKeyInformation KeyInformation { get; }
    }
}
