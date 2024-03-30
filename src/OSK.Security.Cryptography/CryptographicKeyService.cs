using OSK.Security.Cryptography.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace OSK.Security.Cryptography
{
    public abstract class CryptographicKeyService : ICryptographicKeyService
    {
        #region ICryptographicKeyService

        public abstract ValueTask<byte[]> DecryptAsync(byte[] data, CancellationToken cancellationToken = default);

        public abstract ValueTask<byte[]> EncryptAsync(byte[] data, CancellationToken cancellationToken = default);

        #endregion

        #region Helpers

        protected internal abstract bool TrySetKeyInformation(ICryptographicKeyInformation keyInformation);

        #endregion
    }
}
