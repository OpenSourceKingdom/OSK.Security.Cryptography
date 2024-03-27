namespace OSK.Security.Cryptography.Abstractions
{
    public interface ICryptographicKeyServiceProvider
    {
        ISymmetricKeyService<TKeyInformation> GetSymmetricKeyService<TKeyInformation>(TKeyInformation keyInformation)
            where TKeyInformation : class, ISymmetricKeyInformation;

        IAsymmetricKeyService<TKeyInformation> GetAsymmetricKeyService<TKeyInformation>(TKeyInformation keyInformation)
            where TKeyInformation : class, IAsymmetricKeyInformation;
    }
}
