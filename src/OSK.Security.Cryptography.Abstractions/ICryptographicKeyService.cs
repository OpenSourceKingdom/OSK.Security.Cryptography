using System.Threading.Tasks;
using System.Threading;

namespace OSK.Security.Cryptography.Abstractions
{
    public interface ICryptographicKeyService
    {
        ValueTask<byte[]> EncryptAsync(byte[] data, CancellationToken cancellationToken = default);

        ValueTask<byte[]> DecryptAsync(byte[] data, CancellationToken cancellationToken = default);

        bool TrySetKeyInformation(ICryptographicKeyInformation keyInformation);
    }
}
