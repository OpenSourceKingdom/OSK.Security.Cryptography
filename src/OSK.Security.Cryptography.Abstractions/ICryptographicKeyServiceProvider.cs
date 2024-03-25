namespace OSK.Security.Cryptography.Abstractions
{
    public interface ICryptographicKeyServiceProvider
    {
        ISymmetricKeyService<TKeyInformation> GetSymmetricKeyService<TKeyInformation>(TKeyInformation keyInformation)
            where TKeyInformation : SymmetricKeyInformation;

        IAsymmetricKeyService<TKeyInformation> GetAsymmetricKeyService<TKeyInformation>(TKeyInformation keyInformation)
            where TKeyInformation : AsymmetricKeyInformation;
    }
}
