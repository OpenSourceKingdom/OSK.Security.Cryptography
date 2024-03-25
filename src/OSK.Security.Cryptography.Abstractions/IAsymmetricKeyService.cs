using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace OSK.Security.Cryptography.Abstractions
{
    public interface IAsymmetricKeyService<TKeyInformation> : ICryptographicKeyService<TKeyInformation>
        where TKeyInformation: AsymmetricKeyInformation
    {
        ValueTask<byte[]> SignAsync(byte[] data, HashAlgorithmName hashAlgorithmName, CancellationToken cancellationToken = default);

        ValueTask<bool> ValidateSignatureAsync(byte[] data, byte[] signedData, HashAlgorithmName hashAlgorithmName, CancellationToken cancellationToken = default);
    }
}
