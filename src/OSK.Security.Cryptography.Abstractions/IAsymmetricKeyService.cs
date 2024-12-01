using System.Threading;
using System.Threading.Tasks;
using OSK.Hexagonal.MetaData;

namespace OSK.Security.Cryptography.Abstractions
{
    [HexagonalPort(HexagonalPort.Secondary)]
    public interface IAsymmetricKeyService<TKeyInformation> : ICryptographicKeyService<TKeyInformation>
        where TKeyInformation: IAsymmetricKeyInformation
    {
        ValueTask<byte[]> SignAsync(byte[] data, CryptographicSigningAlgorithm signingAlgorithm, CancellationToken cancellationToken = default);

        ValueTask<bool> ValidateSignatureAsync(byte[] data, byte[] signedData, CryptographicSigningAlgorithm signingAlgorithm, CancellationToken cancellationToken = default);
    }
}
