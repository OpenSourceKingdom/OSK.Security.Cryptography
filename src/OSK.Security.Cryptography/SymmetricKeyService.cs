using OSK.Security.Cryptography.Abstractions;

namespace OSK.Security.Cryptography
{
    /// <summary>
    /// A key service that specifically uses <see cref="ISymmetricKeyInformation"/>.
    /// </summary>
    /// <typeparam name="TKeyInformation"><see cref="ISymmetricKeyInformation"/></typeparam>
    public abstract class SymmetricKeyService<TKeyInformation> : CryptographicKeyService<TKeyInformation>, ISymmetricKeyService<TKeyInformation>
        where TKeyInformation : class, ISymmetricKeyInformation
    {
    }
}
