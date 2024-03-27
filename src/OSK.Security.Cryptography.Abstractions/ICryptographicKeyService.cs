using System;
using System.Threading;
using System.Threading.Tasks;

namespace OSK.Security.Cryptography.Abstractions
{
    public interface ICryptographicKeyService<TKeyInformation> : IDisposable
        where TKeyInformation : ICryptographicKeyInformation
    {
        TKeyInformation KeyInformation { get; }

        ValueTask<byte[]> EncryptAsync(byte[] data, CancellationToken cancellationToken = default);

        ValueTask<byte[]> DecryptAsync(byte[] data, CancellationToken cancellationToken = default);
    }
}
