using OSK.Security.Cryptography.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OSK.Security.Cryptography
{
    public abstract class CryptographicKeyService<TKeyInformation> : ICryptographicKeyService<TKeyInformation>
        where TKeyInformation : class, ICryptographicKeyInformation
    {
        #region ICryptographicKeyService

        public TKeyInformation KeyInformation { get; internal set; }

        public abstract ValueTask<byte[]> DecryptAsync(byte[] data, CancellationToken cancellationToken = default);
        public abstract ValueTask<byte[]> EncryptAsync(byte[] data, CancellationToken cancellationToken = default);

        public virtual void Dispose()
        {
            KeyInformation?.Dispose();
            KeyInformation = null;
        }

        #endregion
    }
}
