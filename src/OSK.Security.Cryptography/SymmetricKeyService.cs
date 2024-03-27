using OSK.Security.Cryptography.Abstractions;

namespace OSK.Security.Cryptography
{
    public abstract class SymmetricKeyService<TKeyInformation> : CryptographicKeyService<TKeyInformation>, ISymmetricKeyService<TKeyInformation>
        where TKeyInformation : class, ISymmetricKeyInformation
    {
    }
}
