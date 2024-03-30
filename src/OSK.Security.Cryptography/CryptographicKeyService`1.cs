using OSK.Security.Cryptography.Abstractions;

namespace OSK.Security.Cryptography
{
    public abstract class CryptographicKeyService<TKeyInformation> : CryptographicKeyService, ICryptographicKeyService<TKeyInformation>
        where TKeyInformation : class, ICryptographicKeyInformation
    {
        #region ICryptographicKeyService

        public TKeyInformation KeyInformation { get; protected internal set; }

        public virtual void Dispose()
        {
            KeyInformation?.Dispose();
            KeyInformation = null;
        }

        #endregion

        #region Helpers

        protected internal override bool TrySetKeyInformation(ICryptographicKeyInformation keyInformation)
        {
            if (keyInformation is TKeyInformation typedKeyInformation)
            {
                KeyInformation = typedKeyInformation;
                return true;
            }

            return false;
        }

        #endregion
    }
}
