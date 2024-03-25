using OSK.Security.Cryptography.Abstractions;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace OSK.Security.Cryptography
{
    public abstract class AsymmetricKeyService<TKeyInformation> : CryptographicKeyService<TKeyInformation>, IAsymmetricKeyService<TKeyInformation>
        where TKeyInformation : AsymmetricKeyInformation
    {
        #region Constructors

        protected AsymmetricKeyService(TKeyInformation keyInformation)
            : base(keyInformation)
        {
        }

        #endregion

        #region IAsymmetricKey

        public abstract ValueTask<byte[]> SignAsync(byte[] data, HashAlgorithmName hashAlgorithmName, CancellationToken cancellationToken = default);
        public abstract ValueTask<bool> ValidateSignatureAsync(byte[] data, byte[] signedData, HashAlgorithmName hashAlgorithmName, CancellationToken cancellationToken = default);

        #endregion
    }
}
