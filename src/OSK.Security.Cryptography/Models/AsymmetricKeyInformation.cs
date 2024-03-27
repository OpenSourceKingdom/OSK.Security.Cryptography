using OSK.Security.Cryptography.Abstractions;

namespace OSK.Security.Cryptography.Models
{
    public abstract class AsymmetricKeyInformation<TPublicKeyInformation> : IAsymmetricKeyInformation, ICryptographicKeyInformation<TPublicKeyInformation>
        where TPublicKeyInformation : class, IPublicKeyInformation
    {
        public abstract void Dispose();
        public abstract TPublicKeyInformation GetPublicKeyInformation();
    }
}
