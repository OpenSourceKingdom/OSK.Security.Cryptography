using System;
using System.Threading;
using System.Threading.Tasks;

namespace OSK.Security.Cryptography.Abstractions
{
    public interface ICryptographicKeyService<TKeyInformation> : IDisposable
        where TKeyInformation : CryptographicKeyInformation
    {
        TKeyInformation KeyInformation { get; set; }

        ValueTask<byte[]> EncryptAsync(byte[] data, CancellationToken cancellationToken = default);

        ValueTask<byte[]> DecryptAsync(byte[] data, CancellationToken cancellationToken = default);
    }
}
