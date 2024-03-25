namespace OSK.Security.Cryptography.Abstractions
{
    public interface ISymmetricKeyService<TKeyInformation> : ICryptographicKeyService<TKeyInformation>
        where TKeyInformation: SymmetricKeyInformation
    {
    }
}
