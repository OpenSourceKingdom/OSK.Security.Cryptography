using System.Threading.Tasks;
using System.Threading;
using OSK.Hexagonal.MetaData;

namespace OSK.Security.Cryptography.Abstractions
{
    [HexagonalPort(HexagonalPort.Secondary)]
    public interface ICryptographicKeyService
    {
        /// <summary>
        /// Encrypts data using the cryptographic function internal algorithms
        /// </summary>
        /// <param name="data">The data to encrypt</param>
        /// <param name="cancellationToken">A token to cancel the operation</param>
        /// <returns>The encrypted data</returns>
        ValueTask<byte[]> EncryptAsync(byte[] data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Decrypts data using the cryptographic function internal algorithms
        /// </summary>
        /// <param name="data">The encrypted data needing to be decrpyted</param>
        /// <param name="cancellationToken">A token to cancel the operation</param>
        /// <returns>The decrypted data</returns>
        ValueTask<byte[]> DecryptAsync(byte[] data, CancellationToken cancellationToken = default);
    }
}
